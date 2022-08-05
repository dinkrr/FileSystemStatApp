using FileSystemStatsService.Models;
using FileSystemStatsService.Repository;
using FileSystemStatsService.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace FileSystemStatsServiceTests.Service
{
    [TestClass]
    public class FileSystemStatCollectorTests
    {
        private readonly Mock<IFileSystemDataRepository> _mockRepository;
        private readonly FileSystemStatCollector _statCollector;
        private readonly List<string> _directoryItemNames;
        public FileSystemStatCollectorTests()
        {
            _mockRepository = new Mock<IFileSystemDataRepository>();
            _statCollector = new FileSystemStatCollector(_mockRepository.Object);
            _directoryItemNames = new List<string>() { "File2", "Folder3", "File2" };
        }

        [TestInitialize]
        public void Setup()
        {
            _mockRepository.Setup(x => x.GetByName(It.IsAny<string>()))
                .Returns<string>((name) => new Folder(name, true));

            _mockRepository.Setup(x => x.GetByLevel(It.IsAny<int>())).Returns(_directoryItemNames);

            _mockRepository.Setup(x => x.GetByFilter(It.IsAny<IEnumerable<string>>(), It.IsAny<bool>()))
                .Returns(new List<string> { "Folder2", "File2", "File2", "Folder2" });
        }

        [TestMethod]
        [DataRow("Folder2", 0)]
        public void StartTest(string driveName, int expectedInnercount)
        {
            Assert.AreEqual(expectedInnercount, _statCollector.Start(driveName));
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(-2)]
        public void GetByLevelTest(int level)
        {
            var actualItems = _statCollector.GetByLevel(level);
            if (level < 0)
                Assert.IsNull(actualItems);
            else
                CollectionAssert.AreEqual(_directoryItemNames, (System.Collections.ICollection)actualItems);
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(-2)]
        public void GetUniqueNamesByLevelTest(int level)
        {
            var actualItems = _statCollector.GetUniqueNamesByLevel(level);
            if (level < 0)
                Assert.IsNull(actualItems);
            else
                CollectionAssert.AreEquivalent(_directoryItemNames.Distinct().ToList(), (System.Collections.ICollection)actualItems);
        }

        [TestMethod]
        [DataRow(new string[] { "File2", "Folder2" }, true, new string[] { "File2", "Folder2" })]
        [DataRow(null, false, null)]

        public void GetUniqueNamesByLevelTest(string[] nameFilters, bool isReadonly, string[] expectedItems)
        {
            var actualItems = _statCollector.GetUniqueNamesBy(nameFilters, isReadonly);
            CollectionAssert.AreEquivalent(expectedItems, (System.Collections.ICollection)actualItems);
        }
    }
}
