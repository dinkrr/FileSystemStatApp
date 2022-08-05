using FileSystemStatsService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileSystemStatsServiceTests.Model
{
    [TestClass]
    public class FolderTests
    {
        private readonly Folder _rootDirectory;

        public FolderTests()
        {
            _rootDirectory = DirectoryUtility.GetRootDirectory();
        }

        [TestMethod]
        [DataRow(6)]
        public void GetInnerItemsCountTest(int expectedInnerCount)
        {
            int innerCount = _rootDirectory.GetInnerItemsCount();

            Assert.AreEqual(expectedInnerCount, innerCount);

        }

        [TestMethod]
        [DataRow(7, 3)]
        public void AddItemTest(int expectedInnerCount, int expectedItemsCount)
        {
            _rootDirectory.AddItem(new Folder("Folder4", false));

            int innerCount = _rootDirectory.GetInnerItemsCount();
            Assert.AreEqual(expectedItemsCount, _rootDirectory.Items.Count);
            Assert.AreEqual(expectedInnerCount, innerCount);

        }
    }
}
