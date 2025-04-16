using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horizon_Drive_LTD.DataStructure;

namespace MsTesting1
{
    [TestClass]
    public sealed class BrowseListingsTest
    {
        [TestMethod]
        public void HashTable_ShouldRetrieveInsertedItem()
        {
            // Test Use: Verify that an item inserted into the hash table can be retrieved.

            // Arrange
            var hashTable = new HashTable<string, string>(10);
            var key = "C00001";
            var value = "Toyota Corolla";

            hashTable.Insert(key, value);

            // Act
            var result = hashTable.Search(key);

            // Assert
            Assert.AreEqual(value, result, "The value should match the item inserted into the hash table.");
        }

        [TestMethod]
        public void HashTable_ShouldReturnNull_ForNonExistentKey()
        {
            // Test Use: Ensure the hash table returns null for a non-existent key.

            // Arrange
            var hashTable = new HashTable<string, string>(10);

            // Act
            var result = hashTable.Search("C99999");

            // Assert
            Assert.IsNull(result, "The result should be null for a non-existent key.");
        }

        [TestMethod]
        public void HashTable_ShouldCorrectlyCountItems()
        {
            // Test Use: Validate that the hash table correctly counts the number of items inserted.

            // Arrange
            var hashTable = new HashTable<string, string>(10);
            hashTable.Insert("C00001", "Toyota Corolla");
            hashTable.Insert("C00002", "Honda Civic");

            // Act
            var result = hashTable.GetAllItems().Count();

            // Assert
            Assert.AreEqual(2, result, "The hash table should contain exactly 2 items.");
        }
    }
}
