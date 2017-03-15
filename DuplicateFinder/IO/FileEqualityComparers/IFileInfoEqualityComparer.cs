using System.IO;

namespace DuplicateFinder.IO.FileEqualityComparers
{
    public interface IFileInfoEqualityComparer
    {
        bool Equals(FileInfo f1, FileInfo f2);
    }
}
