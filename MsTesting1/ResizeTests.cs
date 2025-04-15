using System.Linq;
using Horizon_Drive_LTD.DataStructure;

namespace MsTesting1
{
    [TestClass]
    public sealed class HashTableResizeTests
    {
        [TestMethod]
        public void Insert_WhenExceedingLoadFactor_TriggersResizeAndPreservesData()
        {
            // Test Use: Verify that exceeding the load factor triggers resize and preserves existing data.
            // Arrange: Initialize a hash table with low capacity and load factor to trigger resizing
            var hashTable = new HashTable<int, string>(3, 0.75f);

            // Insert enough items to trigger resize
            hashTable.Insert(1, "One");
            hashTable.Insert(2, "Two");
            hashTable.Insert(3, "Three"); // This insertion should trigger the resize

            // Act: Fetch all items and convert to a dictionary for verification
            var items = hashTable.GetAllItems().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            // Assert: Verify the size and data integrity after resize
            Assert.AreEqual(3, items.Count, "The hash table should contain all inserted items after resizing.");
            Assert.AreEqual("One", items[1], "The data associated with key 1 should be preserved.");
            Assert.AreEqual("Two", items[2], "The data associated with key 2 should be preserved.");
            Assert.AreEqual("Three", items[3], "The data associated with key 3 should be preserved.");
        }
    }
}
