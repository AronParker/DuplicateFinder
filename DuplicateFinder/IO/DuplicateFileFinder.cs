using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using DuplicateFinder.Extensions;
using DuplicateFinder.IO.FileEqualityComparers;

namespace DuplicateFinder.IO
{
    public class DuplicateFileFinder
    {
        protected List<FileInfo> _files = new List<FileInfo>();

        private CancellationToken _token;
        private Task _task;
        
        public event FileInfoEventHandler FileAdded;
        public event FileInfoReadOnlyListEventHandler FilesProcessed;
        public event FileInfoReadOnlyListEventHandler DuplicateFound;
        public event FileSystemInfoErrorEventHandler Error;

        public bool IsRunning => _task != null && !_task.IsCompleted;

        public Task RunAsync(IEnumerable<DirectoryInfo> dirs, IFileInfoEqualityComparer fileInfoComparer)
        {
            return RunAsync(dirs, fileInfoComparer, CancellationToken.None);
        }

        public Task RunAsync(IEnumerable<DirectoryInfo> dirs, IFileInfoEqualityComparer fileInfoComparer, CancellationToken token)
        {
            if (dirs == null)
                throw new ArgumentNullException(nameof(dirs));
            if (fileInfoComparer == null)
                throw new ArgumentNullException(nameof(fileInfoComparer));
            if (IsRunning)
                throw new InvalidOperationException("DuplicateFinder is already running.");

            _token = token;
            _task = Task.Run(() => InternalStart(dirs, fileInfoComparer));

            return _task;
        }

        protected virtual void OnFileAdded(FileInfo file)
        {
            FileAdded?.Invoke(this, new FileInfoEventArgs(file));
        }

        protected virtual void OnFilesProcessed(int start, int length)
        {
            var processed = CreateReadOnlyList(start, length);
            FilesProcessed?.Invoke(this, new FileInfoReadOnlyListEventArgs(processed));
        }

        protected virtual void OnDuplicateFound(int start, int length)
        {
            var duplicate = CreateReadOnlyList(start, length);
            DuplicateFound?.Invoke(this, new FileInfoReadOnlyListEventArgs(duplicate));
        }

        protected virtual void OnError(FileSystemInfoException ex)
        {
            Error?.Invoke(this, new FileSystemInfoErrorEventArgs(ex));
        }

        private void InternalStart(IEnumerable<DirectoryInfo> dirs, IFileInfoEqualityComparer fileComparer)
        {
            _files.Clear();
            new FileInfoEnumerator(this).AddDirectories(dirs);
            FindDuplicates(fileComparer);
        }

        private void FindDuplicates(IFileInfoEqualityComparer fileComparer)
        {
            _files.Sort((x, y) => y.Length.CompareTo(x.Length));

            var i = 0;

            while (i < _files.Count)
            {
                _token.ThrowIfCancellationRequested();

                var start = i++;

                while (i < _files.Count && _files[start].Length == _files[i].Length)
                    i++;

                var length = i - start;

                if (length > 1)
                    FindDuplicates(start, length, fileComparer);

                OnFilesProcessed(start, length);
            }
        }

        private void FindDuplicates(int start, int length, IFileInfoEqualityComparer fileInfoComparer)
        {
            try
            {
                if (length == 2)
                {
                    if (fileInfoComparer.Equals(_files[start], _files[start + 1]))
                        OnDuplicateFound(start, length);
                }
                else
                {
                    if (fileInfoComparer is IFileEqualityComprarer fileComparer)
                        new MultiFileEqualityComparer(this, start, length, fileComparer).FindDuplicates();
                    else
                        GroupEqualFileInfosAtTop(start, length, fileInfoComparer);
                }
            }
            catch (FileSystemInfoException ex)
            {
                OnError(ex);
            }
        }

        private void GroupEqualFileInfosAtTop(int start, int length, IFileInfoEqualityComparer fileInfoComparer)
        {
            for (var i = 0; i < length;)
            {
                var equalFiles = 1;

                for (var j = i + 1; j < length; j++)
                {
                    var f1 = _files[start + i];
                    var f2 = _files[start + j];

                    if (fileInfoComparer.Equals(f1, f2))
                    {
                        equalFiles++;
                        _files.Swap(start + i, start + j);
                    }
                }

                if (equalFiles > 1)
                    OnDuplicateFound(start + i, equalFiles);

                i += equalFiles;
            }
        }

        private IReadOnlyList<FileInfo> CreateReadOnlyList(int start, int length)
        {
            var array = new FileInfo[length];

            for (var i = 0; i < length; i++)
                array[i] = _files[i + start];

            return array;
        }

        private struct FileInfoEnumerator
        {
            private DuplicateFileFinder _df;
            private List<DirectoryInfo> _stack;

            public FileInfoEnumerator(DuplicateFileFinder df)
            {
                _df = df;
                _stack = new List<DirectoryInfo>();
            }
            
            public void AddDirectories(IEnumerable<DirectoryInfo> dirs)
            {
                foreach (var dir in dirs)
                {
                    _df._token.ThrowIfCancellationRequested();

                    if (dir == null)
                        continue;

                    _stack.Add(dir);

                    while (_stack.Count > 0)
                    {
                        _df._token.ThrowIfCancellationRequested();

                        var index = _stack.Count - 1;
                        var curDir = _stack[index];
                        _stack.RemoveAt(index);

                        AddDirectory(curDir);

                        if (_stack.Count > index)
                            _stack.Reverse(index, _stack.Count - index);
                    }
                }
            }

            private void AddDirectory(DirectoryInfo curDir)
            {
                try
                {
                    foreach (var fsi in curDir.EnumerateFileSystemInfos())
                    {
                        if (fsi is FileInfo file)
                            AddFile(file);
                        else if (fsi is DirectoryInfo dir)
                            _stack.Add(dir);
                    }
                }
                catch (Exception ex) when (ex is IOException ||
                                           ex is UnauthorizedAccessException ||
                                           ex is SecurityException)
                {
                    _df.OnError(new FileSystemInfoException(curDir, ex));
                }
            }

            private void AddFile(FileInfo file)
            {
                _df._files.Add(file);
                _df.OnFileAdded(file);
            }
        }

        private struct MultiFileEqualityComparer
        {
            private DuplicateFileFinder _df;
            private int _start;
            private int _length;
            private IFileEqualityComprarer _fileComparer;

            private FileStream[] _fs;
            private int _fileStreams;

            public MultiFileEqualityComparer(DuplicateFileFinder df, int start, int length, IFileEqualityComprarer fileComparer)
            {
                _df = df;
                _start = start;
                _length = length;
                _fileComparer = fileComparer;

                _fs = new FileStream[length];
                _fileStreams = _fs.Length;
            }

            public void FindDuplicates()
            {
                try
                {
                    OpenFiles();

                    for (var i = 0; (_fileStreams - i) > 1;)
                    {
                        var equalFiles = GetEqualFiles(i);

                        if (equalFiles > 1)
                            _df.OnDuplicateFound(_start + i, equalFiles);

                        i += equalFiles;
                    }
                }
                finally
                {
                    CloseFiles();
                }
            }

            private void OpenFiles()
            {
                for (var i = 0; i < _fileStreams;)
                {
                    try
                    {
                        _fs[i] = FileSystem.OpenFile(_df._files[_start + i]);
                        i++;
                    }
                    catch (FileSystemInfoException ex)
                    {
                        _df.OnError(ex);

                        _fileStreams--;
                        _df._files.Swap(_start + i, _start + _fileStreams);
                    }
                }
            }

            private int GetEqualFiles(int i)
            {
                var f1 = GetFileInfo(i);
                var fs1 = GetFileStream(i);

                var equalFiles = 1;

                for (var j = i + 1; j < _fileStreams; j++)
                {
                    var f2 = GetFileInfo(j);
                    var fs2 = GetFileStream(j);

                    try
                    {
                        if (_fileComparer.Equals(f1, fs1, f2, fs2))
                        {
                            Swap(i + equalFiles, j);
                            equalFiles++;
                        }
                    }
                    catch (FileSystemInfoException ex) when (ex.FileSystemInfo == f1)
                    {
                        _df.OnError(ex);
                        break;
                    }
                    catch (FileSystemInfoException ex) when (ex.FileSystemInfo == f2)
                    {
                        _df.OnError(ex);
                        _fileStreams--;

                        if (j != _fileStreams)
                            Swap(j, _fileStreams);
                    }
                }

                return equalFiles;
            }

            private void CloseFiles()
            {
                for (var i = 0; i < _fs.Length; i++)
                    if (_fs[i] != null)
                        _fs[i].Dispose();
            }

            private FileInfo GetFileInfo(int index)
            {
                return _df._files[_start + index];
            }

            private FileStream GetFileStream(int index)
            {
                return _fs[index];
            }

            private void Swap(int i, int j)
            {
                _df._files.Swap(_start + i, _start + j);
                _fs.Swap(i, j);
            }
        }
    }
}
