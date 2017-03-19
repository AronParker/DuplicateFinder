using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuplicateFinder.IO;
using DuplicateFinder.IO.FileEqualityComparers;
using DuplicateFinder.Localizations;
using static DuplicateFinder.NativeMethods;

namespace DuplicateFinder.Forms
{
    public partial class DuplicatesForm : Form
    {
        private const int MinRefreshInterval = 500;

        private const int DirectoryExceptionImageIndex = 0;
        private const int FileExceptionImageIndex = 1;

        private static Color s_foreColor1 = Color.FromArgb(unchecked((int)0xFF000000));
        private static Color s_foreColor2 = Color.FromArgb(unchecked((int)0xFF808080));
        private static Color s_backColor1 = Color.FromArgb(unchecked((int)0xFFFFFFFF));
        private static Color s_backColor2 = Color.FromArgb(unchecked((int)0xFFF0F0F0));

        private List<ListViewItem> _duplicates = new List<ListViewItem>();
        private List<ListViewItem> _errors = new List<ListViewItem>();
        private DuplicatesFormState _state = DuplicatesFormState.Idle;
        private bool _closeAfterCancellation = false;

        private DuplicateFinderTask _duplicateFinderTask;
        private DirectoryInfo[] _dirs;
        private CancellationTokenSource _cts;
        
        public DuplicatesForm(DirectoryInfo[] dirs)
        {
            if (dirs == null)
                throw new ArgumentNullException(nameof(dirs));

            _duplicateFinderTask = new DuplicateFinderTask(this);
            _dirs = dirs;            

            InitializeComponent();
        }

        private enum DuplicatesFormState
        {
            Idle,
            Running,
            Canceling,
            Done,
        }

        protected override async void OnLoad(EventArgs e)
        {
            _duplicateFinderTask.Init(_dirs);

            using (_cts = new CancellationTokenSource())
                await _duplicateFinderTask.RunAsync(_cts.Token);
            
            if (_closeAfterCancellation)
                Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            switch (_state)
            {
                case DuplicatesFormState.Running:
                    e.Cancel = true;
                    
                    if (MessageBox.Show("Are you sure you want to cancel?", "Confirm Cancelation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        return;

                    _cts.Cancel();
                    _state = DuplicatesFormState.Canceling;
                    _closeAfterCancellation = true;
                    break;
                default:
                    break;
            }
        }

        private void DeleteSelectedFiles(Microsoft.VisualBasic.FileIO.RecycleOption recycle)
        {
            var selected = _duplicatesListView.SelectedIndices;

            if (selected.Count == 0)
                return;

            _duplicatesListView.BeginUpdate();

            try
            {
                for (var i = 0; i < selected.Count; i++)
                {
                    var index = selected[i];

                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(((FileInfo)_duplicates[index].Tag).FullName,
                                                                       Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                                                                       recycle,
                                                                       Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
                    _duplicates[index].ForeColor = s_foreColor2;
                }
            }
            catch (Exception ex) when (ex is IOException ||
                                       ex is UnauthorizedAccessException ||
                                       ex is SecurityException)
            {
                MessageBox.Show("Failed to delete file permanently: " + ex.Message, "Failed to delete file permanently", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OperationCanceledException)
            {
            }

            _duplicatesListView.EndUpdate();
            _duplicatesListView.SelectedIndices.Clear();
        }

        private void DuplicatesListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = _duplicates[e.ItemIndex];
        }

        private void ErrorsListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = _errors[e.ItemIndex];
        }

        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            var focused = _duplicatesListView.FocusedItem;

            if (focused == null)
                e.Cancel = true;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var focused = _duplicatesListView.FocusedItem?.Tag as FileInfo;

            if (focused == null)
                return;

            try
            {
                using (Process.Start(focused.FullName))
                {
                }
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show("Failed to open file: " + ex.Message, "Failed to open file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var focused = _duplicatesListView.FocusedItem?.Tag as FileInfo;

            if (focused == null)
                return;

            var hr = SHParseDisplayName(focused.FullName, IntPtr.Zero, out var pidl, 0, IntPtr.Zero);

            if (hr >= 0)
            {
                using (pidl)
                {
                    hr = SHOpenFolderAndSelectItems(pidl, 0, IntPtr.Zero, 0);

                    if (hr >= 0)
                        return;
                }
            }
            
            var ex = Marshal.GetExceptionForHR(hr);

            MessageBox.Show("Failed to open file location: " + ex.Message, "Failed to open file location", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedFiles(Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
        }

        private void DeletePermanentlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedFiles(Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently);
        }

        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var focused = _duplicatesListView.FocusedItem?.Tag as FileInfo;

            if (focused == null)
                return;

            var shellExecuteInfo = new SHELLEXECUTEINFO()
            {
                cbSize = (uint)Marshal.SizeOf<SHELLEXECUTEINFO>(),
                lpVerb = "properties",
                lpFile = focused.FullName,
                nShow = SW.SHOW,
                fMask = SEE_MASK.INVOKEIDLIST
            };

            ShellExecuteEx(ref shellExecuteInfo);
        }

        private class DuplicateFinderTask
        {
            private DuplicatesForm _duplicatesForm;
            private DuplicateFileFinderEx _finder;
            private DirectoryInfo[] _dirs;
            private IFileInfoEqualityComparer _fileInfoComparer;

            private IntPtr _sysImageList = IntPtr.Zero;
            
            public DuplicateFinderTask(DuplicatesForm duplicatesForm)
            {
                _duplicatesForm = duplicatesForm;
                _finder = new DuplicateFileFinderEx(this);
                _fileInfoComparer = new FileEqualityComparer();
            }

            public void Init(DirectoryInfo[] dirs)
            {
                _dirs = dirs;

                _finder.Init();
            }

            public async Task RunAsync(CancellationToken ct)
            {
                try
                {
                    _duplicatesForm._state = DuplicatesFormState.Running;

                    await _finder.RunAsync(_dirs, _fileInfoComparer, ct);
                    Update();

                    _duplicatesForm._state = DuplicatesFormState.Done;
                    Finish();
                }
                catch (OperationCanceledException)
                {
                    _duplicatesForm._state = DuplicatesFormState.Done;
                }
            }

            private void DisplayAddedItems()
            {
                _duplicatesForm._progressLabel.Text = $"Adding files... ({Localization.GetPlural(_finder.AddedFiles, "file")} found, {Localization.GetHumanReadableFileSize(_finder.AddedSize)} in total)";
            }

            private void Update()
            {
                var duplicatesAdded = _finder.PendingDuplicates.Count > 0;
                var errorsAdded = _finder.PendingErrors.Count > 0;

                if (duplicatesAdded)
                    FlushDuplicates();

                if (errorsAdded)
                    FlushErrors();

                UpdateProgress();
            }

            private void FlushDuplicates()
            {
                if (_sysImageList != _finder.CurrentSysImageList)
                {
                    var oldImageList = SendMessage(_duplicatesForm._duplicatesListView.Handle, LVM_SETIMAGELIST, new IntPtr((int)LVSIL.SMALL), _finder.CurrentSysImageList);
                    _sysImageList = _finder.CurrentSysImageList;
                }

                _duplicatesForm._duplicates.AddRange(_finder.PendingDuplicates);
                _finder.PendingDuplicates.Clear();
                _duplicatesForm._duplicatesListView.VirtualListSize = _duplicatesForm._duplicates.Count;

                _duplicatesForm._duplicatesLabel.Text = $"{Localization.GetPlural(_finder.DuplicateFiles, "duplicate")} found ({Localization.GetHumanReadableFileSize(_finder.DuplicatesSize)})";
            }

            private void FlushErrors()
            {
                _duplicatesForm._errors.AddRange(_finder.PendingErrors);
                _finder.PendingErrors.Clear();
                _duplicatesForm._errorsListView.VirtualListSize = _duplicatesForm._errors.Count;

                _duplicatesForm._errorsLabel.Text = $"{Localization.GetPlural(_duplicatesForm._errors.Count, "error")} occured";
            }

            private void UpdateProgress()
            {
                var localizedAddedFiles = Localization.GetPlural(_finder.AddedFiles, "file");
                var localizedAddedSize = Localization.GetHumanReadableFileSize(_finder.AddedSize);
                var localizedProcessedFiles = Localization.GetPlural(_finder.ProcessedFiles, "file");
                var localizedProcessedSize = Localization.GetHumanReadableFileSize(_finder.ProcessedSize);

                _duplicatesForm._progressLabel.Text = $"Processing files... ({localizedProcessedFiles} ({localizedProcessedSize}) processed out of {localizedAddedFiles} ({localizedAddedSize}))";

                var percentage = _finder.AddedFiles == 0 ? 1.0 : (double)_finder.ProcessedFiles / _finder.AddedFiles;

                _duplicatesForm._progressBar.Style = ProgressBarStyle.Continuous;
                _duplicatesForm._progressBar.Value = (int)(percentage * 10000);
            }

            private void Finish()
            {
                var elapsed = DateTimeOffset.UtcNow - _finder.Start;

                var localizedDuplicateFiles = Localization.GetPlural(_finder.DuplicateFiles, "duplicate");
                var localizedDuplicatesSize = Localization.GetHumanReadableFileSize(_finder.DuplicatesSize);
                var localizedProcessedFiles = Localization.GetPlural(_finder.ProcessedFiles, "file");
                var localizedProcessedSize = Localization.GetHumanReadableFileSize(_finder.ProcessedSize);

                _duplicatesForm._progressLabel.Text = $"Found {localizedDuplicateFiles} ({localizedDuplicatesSize}) out of {localizedProcessedFiles} ({localizedProcessedSize}) in {Localization.GetHumanReadableTimeSpan(elapsed)}";
            }

            private class DuplicateFileFinderEx : DuplicateFileFinder
            {
                private DuplicateFinderTask _duplicateFinderTask;

                private DateTime _lastUpdate;
                private bool _lastColor;

                public DuplicateFileFinderEx(DuplicateFinderTask duplicateFinderTask)
                {
                    _duplicateFinderTask = duplicateFinderTask;
                }

                public DateTime Start { get; private set; }
                public int AddedFiles { get; private set; }
                public long AddedSize { get; private set; }
                public int ProcessedFiles { get; private set; }
                public long ProcessedSize { get; private set; }
                public int DuplicateFiles { get; private set; }
                public long DuplicatesSize { get; private set; }

                public List<ListViewItem> PendingDuplicates { get; } = new List<ListViewItem>();
                public List<ListViewItem> PendingErrors { get; } = new List<ListViewItem>();
                public IntPtr CurrentSysImageList { get; private set; } = IntPtr.Zero;

                public void Init()
                {
                    _lastUpdate = DateTime.MinValue;
                    _lastColor = false;

                    Start = DateTime.UtcNow;
                    AddedFiles = 0;
                    AddedSize = 0;
                    ProcessedFiles = 0;
                    ProcessedSize = 0;
                    DuplicateFiles = 0;
                    DuplicatesSize = 0;

                    PendingDuplicates.Clear();
                    PendingErrors.Clear();
                }

                protected override void OnFileAdded(FileInfo file)
                {
                    AddedFiles++;
                    AddedSize += file.Length;

                    if (ShouldUpdate())
                        RequestDisplayAddedItems();
                }

                protected override void OnFilesProcessed(int start, int length)
                {
                    ProcessedFiles += length;

                    var maxExclusive = start + length;

                    for (var i = start; i < maxExclusive; i++)
                        ProcessedSize += _files[i].Length;

                    if (ShouldUpdate())
                        RequestUpdate();
                }

                protected override void OnDuplicateFound(int start, int length)
                {
                    var maxExclusive = start + length;

                    for (var i = start; i < maxExclusive; i++)
                        PendingDuplicates.Add(CreateDuplicateItem(_files[i]));

                    DuplicateFiles += length - 1;
                    DuplicatesSize += (length - 1) * _files[start].Length;

                    _lastColor = !_lastColor;

                    if (ShouldUpdate())
                        RequestUpdate();
                }

                protected override void OnError(FileSystemInfoException ex)
                {
                    var isDir = ex.FileSystemInfo is DirectoryInfo;
                    var lvi = new ListViewItem(new[] { isDir ? "Directory error" : "File error", ex.FileSystemInfo.Name, ex.FileSystemInfo.FullName, ex.Message }, isDir ? DirectoryExceptionImageIndex : FileExceptionImageIndex)
                    {
                        Tag = ex
                    };

                    PendingErrors.Add(lvi);

                    if (ShouldUpdate())
                        RequestUpdate();
                }

                private bool ShouldUpdate()
                {
                    var now = DateTime.UtcNow;

                    if ((now - _lastUpdate).TotalMilliseconds >= MinRefreshInterval)
                    {
                        _lastUpdate = now;
                        return true;
                    }

                    return false;
                }

                private void RequestDisplayAddedItems()
                {
                    if (_duplicateFinderTask._duplicatesForm.InvokeRequired)
                        _duplicateFinderTask._duplicatesForm.Invoke((MethodInvoker)_duplicateFinderTask.DisplayAddedItems);
                    else
                        _duplicateFinderTask.DisplayAddedItems();
                }

                private void RequestUpdate()
                {
                    if (_duplicateFinderTask._duplicatesForm.InvokeRequired)
                        _duplicateFinderTask._duplicatesForm.Invoke((MethodInvoker)_duplicateFinderTask.Update);
                    else
                        _duplicateFinderTask.Update();
                }

                private ListViewItem CreateDuplicateItem(FileInfo fileInfo)
                {
                    var sfi = default(SHFILEINFO);
                    var sysImageList = SHGetFileInfo(fileInfo.FullName, 0, ref sfi, (uint)Marshal.SizeOf<SHFILEINFO>(), SHGFI.DISPLAYNAME | SHGFI.TYPENAME | SHGFI.SYSICONINDEX);
                    ListViewItem lvi;

                    if (sysImageList == IntPtr.Zero)
                    {
                        lvi = new ListViewItem(new[] { fileInfo.Name,
                                                       Localization.GetHumanReadableFileSize(fileInfo.Length),
                                                       fileInfo.LastWriteTime.ToString(),
                                                       Path.GetExtension(fileInfo.Name),
                                                       fileInfo.FullName});
                    }
                    else
                    {
                        lvi = new ListViewItem(new[] { sfi.szDisplayName,
                                                       Localization.GetHumanReadableFileSize(fileInfo.Length),
                                                       fileInfo.LastWriteTime.ToString(),
                                                       sfi.szTypeName,
                                                       fileInfo.FullName}, sfi.iIcon);

                        CurrentSysImageList = sysImageList;
                    }

                    lvi.ForeColor = s_foreColor1;
                    lvi.BackColor = _lastColor ? s_backColor1 : s_backColor2;
                    lvi.Tag = fileInfo;

                    return lvi;
                }
            }
        }
    }
}
