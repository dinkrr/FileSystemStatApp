using System.Collections.Generic;
using System.Linq;

namespace FileSystemStatsService.Models
{
    public class Folder : IDirectoryItem
    {
        public string Name { get; set; }
        public int Level { get; set; } = 0;
        public bool IsReadonly { get; set; }
        public List<IDirectoryItem> Items { get; set; }

        public Folder(string name, bool isReadonly)
        {
            Name = name;
            IsReadonly = isReadonly;
            Items = new List<IDirectoryItem>();
        }

        public void AddItem(IDirectoryItem item)
        {
            if (!Items.Contains(item))
            {
                item.Level++;
                if (item is Folder)
                    (item as Folder).Items.ForEach(x => x.Level++);
                Items.Add(item);
            }
        }

        public Folder GetFolderByName(string name)
        {
            return Items.Where(item => item.Name == name) as Folder;
        }

        public int GetInnerItemsCount()
        {
            int count = 0;
            foreach (var item in Items)
            {
                count += item.GetInnerItemsCount();
            }
            return Items.Count + count;
        }
    }
}