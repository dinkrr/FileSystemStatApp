using FileSystemStatsService.Models;

namespace FileSystemStatsServiceTests
{
    static class DirectoryUtility
    {

        public static Folder GetRootDirectory()
        {
            Folder _rootDirectoryItem = new Folder("RootFolder", false);
            Folder folder1 = new Folder("Folder1", true);
            Folder folder2 = new Folder("Folder2", false);
            File file1 = new File("File1", true);
            File file2 = new File("File2", true);
            folder1.AddItem(file1);
            folder1.AddItem(file2);
            folder1.AddItem(folder2);

            Folder folder3 = new Folder("Folder3", false);
            File file3 = new File("File3", true);
            folder3.AddItem(file3);

            _rootDirectoryItem.AddItem(folder1);
            _rootDirectoryItem.AddItem(folder3);
            return _rootDirectoryItem;
        }

    }
}
