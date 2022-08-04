namespace FileSystemStatsService.Models
{
    public interface IDirectoryItem
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public bool IsReadonly { get; set; }
        int GetInnerItemsCount();
    }
}