using System;
using System.Collections.Generic;
using System.IO;

namespace DuplicateFinder.IO
{
    public class FileInfoReadOnlyListEventArgs : EventArgs
    {
        public FileInfoReadOnlyListEventArgs(IReadOnlyList<FileInfo> files)
        {
            Files = files;
        }

        public IReadOnlyList<FileInfo> Files { get; }
    }
}
