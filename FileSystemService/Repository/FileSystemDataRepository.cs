using FileSystemStatsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileSystemStatsService.Repository
{
    public class FileSystemDataRepository : IFileSystemDataRepository
    {
        private Folder _rootDirectoryItem;
        public FileSystemDataRepository()
        {
            Setup();
        }

        private void Setup()
        {
            _rootDirectoryItem = new Folder("RootFolder");
            Folder folder1 = new Folder("Folder1");
            Folder folder2 = new Folder("Folder2");
            File file1 = new File("File1");
            File file2 = new File("File2");
            folder1.AddItem(file1);
            folder1.AddItem(file2);
            folder1.AddItem(folder2);

            Folder folder3 = new Folder("Folder3");
            File file3 = new File("File3");
            folder3.AddItem(file3);

            _rootDirectoryItem.AddItem(folder1);
            _rootDirectoryItem.AddItem(folder3);
        }

        public Folder GetRootItem()
        {
            return _rootDirectoryItem;
        }

        public IDirectoryItem GetByName(string name)
        {
            return FindItemByName(_rootDirectoryItem, name);
        }

        private IDirectoryItem FindItemByName(IDirectoryItem directoryItem, string name)
        {
            if (directoryItem.Name == name)
                return directoryItem;
            if (directoryItem is Folder)
            {
                var folderItem = directoryItem as Folder;
                foreach (IDirectoryItem item in folderItem.Items)
                {
                    var innerItem = FindItemByName(item, name);
                    if (innerItem != null)
                    {
                        return innerItem;
                    }
                }
            }
            return null;
        }

        public IEnumerable<string> GetByLevel(int level)
        {
            return FindItemNamesByLevel(_rootDirectoryItem, level);
        }

        private IEnumerable<string> FindItemNamesByLevel(Folder rootDirectoryItem, int level)
        {
            List<string> list = new List<string>();
            if (rootDirectoryItem.Level == level)
                list.Add(rootDirectoryItem.Name);
            foreach (IDirectoryItem item in rootDirectoryItem.Items)
            {
                if (item.Level == level)
                {
                    list.Add(item.Name);
                }
                else if (item is Folder)
                    list.AddRange(FindItemNamesByLevel((Folder)item, level));
            }
            return list;
        }
    }
}
