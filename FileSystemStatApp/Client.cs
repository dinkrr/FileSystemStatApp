using FileSystemStatsService.Interfaces;
using FileSystemStatsService.Repository;
using FileSystemStatsService.Service;
using System;
using System.Collections;

namespace FileSystemStatApp
{
    public class Client
    {
        static void Main(string[] args)
        {
            IFileSystemStatCollector collector = new FileSystemStatCollector(new FileSystemDataRepository());

            foreach (var item in collector.GetUniqueNamesBy(new string[] { "File1" }, true))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
