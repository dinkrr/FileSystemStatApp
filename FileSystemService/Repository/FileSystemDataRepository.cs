using FileSystemStatsService.Models;
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
            if (_rootDirectoryItem.Name == name)
                return GetRootItem();
            return GetItem(_rootDirectoryItem.Items, name);
        }

        private IDirectoryItem GetItem(List<IDirectoryItem> items, string name) //File3
        {
            //var item = items.Where(item => item.Name == name).FirstOrDefault();
            //if(item == null && item is Folder)
            //    return GetItem((item as Folder).Items, name);
            //return item;

            foreach (IDirectoryItem item in items) //file1, file2, folder2 --> file3
            {
                if(item.Name == name)
                    return item;
                if(item is Folder)
                    return GetItem(((Folder)item).Items, name);   
            }
            return null;
        }

        //If item is in the Items of rootDirectory, then return using where condition,
        //if 
    }
}
