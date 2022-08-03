using FileSystemStatsService.Interfaces;
using FileSystemStatsService.Repository;
using FileSystemStatsService.Service;
using System;

namespace FileSystemStatApp
{
    public class Client
    {
        static void Main(string[] args)
        {
            IFileSystemStatCollector collector = new FileSystemStatCollector(new FileSystemDataRepository());

            Console.WriteLine(collector.Start("Folder2"));

            Console.ReadKey();
        }
    }
}
