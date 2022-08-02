using FileSystemStatsService.Models;

namespace FileSystemStatsService.Repository
{
    public interface IFileSystemDataRepository
    {
        Folder GetRootItem();
        IDirectoryItem GetByName(string name);
    }
}
