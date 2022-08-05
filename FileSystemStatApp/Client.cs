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

            Console.WriteLine("Start()-> Number of FS items:-");
            Console.WriteLine(collector.Start("Folder1"));

            Console.WriteLine("Unique Name by Level:-");
            foreach (var item in collector.GetUniqueNamesByLevel(2))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Unique Name by Filter:-");
            foreach (var item in collector.GetUniqueNamesBy(new string[] { "File1" }, true))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
