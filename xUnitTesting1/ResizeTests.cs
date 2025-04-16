using System.Linq;
using Xunit;
using Horizon_Drive_LTD.DataStructure;

namespace HorizonDriveTests
{
    public class HashTableResizeTests
    {
        [Fact]
        public void Insert_WhenExceedingLoadFactor_TriggersResizeAndPreservesData()
        {
            // Arrange
            var hashTable = new HashTable<int, string>(3, 0.75f); // Low capacity and load factor to trigger resize

            // Insert enough items to trigger resize
            hashTable.Insert(1, "One");
            hashTable.Insert(2, "Two");
            hashTable.Insert(3, "Three"); // Should trigger resize

            // Act - fetch all items to verify they were preserved
            var items = hashTable.GetAllItems().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            // Assert
            Assert.Equal(3, items.Count);
            Assert.Equal("One", items[1]);
            Assert.Equal("Two", items[2]);
            Assert.Equal("Three", items[3]);
        }
    }
}
