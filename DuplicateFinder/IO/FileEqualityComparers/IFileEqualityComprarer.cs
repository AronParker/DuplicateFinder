using System.IO;

namespace DuplicateFinder.IO.FileEqualityComparers
{
    public interface IFileEqualityComprarer : IFileInfoEqualityComparer
    {
        bool Equals(FileInfoStream fs1, FileInfoStream fs2);
    }
}
