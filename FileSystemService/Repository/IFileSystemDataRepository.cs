using FileSystemStatsService.Models;
using System.Collections.Generic;

namespace FileSystemStatsService.Repository
{
    public interface IFileSystemDataRepository
    {
        Folder GetRootItem();
        IDirectoryItem GetByName(string name);
        IEnumerable<string> GetByLevel(int level);
    }
}
