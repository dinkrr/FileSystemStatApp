namespace FileSystemStatsService.Models
{
    public interface IDirectoryItem
    {
        public string Name { get; set; }
        int GetInnerItemsCount();
    }
}