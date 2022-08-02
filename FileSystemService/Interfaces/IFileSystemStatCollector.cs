using System.Collections.Generic;

namespace FileSystemStatsService.Interfaces
{
    public interface IFileSystemStatCollector
    {
        int Start(string driveLetter);
        IEnumerable<string> GetByLevel(int level = 0);
        IEnumerable<string> GetUniqueNamesByLevel(int level = 0);
        IEnumerable<string> GetUniqueNamesBy(IEnumerable<string> nameFilter, bool isReadOnly);
    }
}
