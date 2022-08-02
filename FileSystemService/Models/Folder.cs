using System.Collections.Generic;
using System.Linq;

namespace FileSystemStatsService.Models
{
    public class Folder : IDirectoryItem
    {
        public string Name { get; set; }
        public List<IDirectoryItem> Items { get; set; }

        public Folder(string name)
        {
            Name = name;
            Items = new List<IDirectoryItem>();
        }

        public void AddItem(IDirectoryItem item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
        }

        public Folder GetFolderByName(string name)
        {
            return Items.Where(item => item.Name == name) as Folder;
        }

        public int GetInnerItemsCount()
        {
            //Main crux of Composite Pattern
            foreach(var item in Items)
            {
                item.GetInnerItemsCount();
            }
            return Items.Count;
        }
    }
}