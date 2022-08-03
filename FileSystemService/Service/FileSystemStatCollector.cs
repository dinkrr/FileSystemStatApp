using FileSystemStatsService.Interfaces;
using FileSystemStatsService.Models;
using FileSystemStatsService.Repository;
using System;
using System.Collections.Generic;

namespace FileSystemStatsService.Service
{
    public class FileSystemStatCollector : IFileSystemStatCollector
    {
        private readonly IFileSystemDataRepository _repository;

        public FileSystemStatCollector(IFileSystemDataRepository repository)
        {
            _repository = repository;
        }

        public int Start(string driveLetter)
        {
            var item = _repository.GetByName(driveLetter);
            Console.WriteLine($"Level of " + item.Name + " is " + item.Level);
            if (item is Folder)
                return item.GetInnerItemsCount();
            return 0;
        }

        public IEnumerable<string> GetByLevel(int level = 0)
        {
            return _repository.GetByLevel(level);
        }

        public IEnumerable<string> GetUniqueNamesByLevel(int level = 0)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetUniqueNamesBy(IEnumerable<string> nameFilter, bool isReadOnly)
        {
            throw new NotImplementedException();
        }
    }
}
