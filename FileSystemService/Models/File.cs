namespace FileSystemStatsService.Models
{
    public class File : IDirectoryItem
    {
        public string Name { get; set; }
        public int Level { get; set; } = 0;
        public bool IsReadonly { get; set; }

        public File(string name, bool isReadonly)
        {
            Name = name;
            IsReadonly = isReadonly;
        }

        public int GetInnerItemsCount()
        {
            return 0;
        }
    }
}
