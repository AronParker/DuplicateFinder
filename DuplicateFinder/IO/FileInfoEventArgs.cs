using System;
using System.IO;

namespace DuplicateFinder.IO
{
    public class FileInfoEventArgs : EventArgs
    {
        public FileInfoEventArgs(FileInfo file)
        {
            File = file;
        }

        public FileInfo File { get; }
    }
}
