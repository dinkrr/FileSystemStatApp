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
            _rootDirectoryItem = new Folder("RootFolder", false);
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

        public IEnumerable<string> GetByFilter(IEnumerable<string> nameFilters, bool isReadonly)
        {
            return FindItemNamesByFilter(_rootDirectoryItem, nameFilters, isReadonly);
        }

        private IEnumerable<string> FindItemNamesByFilter(Folder rootDirectoryItem, IEnumerable<string> nameFilters, bool isReadonly)
        {
            List<string> nameByFilters = new List<string>();
            var name = nameFilters.ToList();
            if (name.Contains(rootDirectoryItem.Name) && rootDirectoryItem.IsReadonly == isReadonly)
                nameByFilters.Add(rootDirectoryItem.Name);

            foreach (IDirectoryItem item in rootDirectoryItem.Items)
            {
                if (name.Contains(item.Name) && item.IsReadonly == isReadonly)
                {
                    nameByFilters.Add(item.Name);
                }
                else if (item is Folder)
                    nameByFilters.AddRange(FindItemNamesByFilter((Folder)item, nameFilters, isReadonly));
            }
            return nameByFilters;
        }
    }
}
