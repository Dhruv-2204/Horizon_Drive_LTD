using System;
using Horizon_Drive_LTD.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTesting1
{
    [TestClass]
    public sealed class ViewDealTests
    {
        [TestMethod]
        public void HashTable_ShouldRetrieveInsertedCarDetails()
        {
            // Test Use: Verify that car details inserted into the hash table can be retrieved.

            // Arrange
            var expected = "Toyota Corolla Sedan";
            var carHashTable = new HashTable<string, string>(100); // Reduced size for simplicity
            var key = "C00001"; // Sample Car ID
            carHashTable.Insert(key, expected);

            // Act
            var result = carHashTable.Search(key);

            // Assert
            Assert.AreEqual(expected, result, "The retrieved car details should match the inserted data.");
        }

        [TestMethod]
        public void HashTable_ShouldReturnNull_ForInvalidCarID()
        {
            // Test Use: Verify that null is returned when the car ID is not found in the hash table.

            // Arrange
            var carHashTable = new HashTable<string, string>(100); // Reduced size for simplicity

            // Act
            var result = carHashTable.Search("C99999"); // Invalid Car ID

            // Assert
            Assert.IsNull(result, "Null should be returned for a non-existent car ID.");
        }
    }


}
