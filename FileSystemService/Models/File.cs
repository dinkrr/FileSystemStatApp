namespace FileSystemStatsService.Models
{
    public class File : IDirectoryItem
    {
        public string Name { get; set; }
        public File(string name)
        {
            Name = name;
        }

        public int GetInnerItemsCount()
        {
            return 0;
        }
    }
}
