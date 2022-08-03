namespace FileSystemStatsService.Models
{
    public interface IDirectoryItem
    {
        public string Name { get; set; }
        public int Level { get; set; }
        int GetInnerItemsCount();
    }
}