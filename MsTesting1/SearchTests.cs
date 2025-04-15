using Horizon_Drive_LTD.DataStructure;

namespace MsTesting1
{
    [TestClass]
    public sealed class SearchTests
    {
        [TestMethod]
        public void Search_ExistingKey_ReturnsCorrectValue()
        {
            // Test Use: Verify that searching for an existing key returns the correct value.
            // Arrange: Initialize a hash table and add a key-value pair
            var ht = new HashTable<int, string>(10);
            ht.Insert(99, "Mauritius");

            // Act: Search for the existing key
            var result = ht.Search(99);

            // Assert: Verify the value associated with the key
            Assert.AreEqual("Mauritius", result, "Searching for an existing key should return the correct value.");
        }

        [TestMethod]
        public void Search_NonExistentKey_ReturnsDefault()
        {
            // Test Use: Verify that searching for a non-existent key returns the default value (null).
            // Arrange: Initialize a hash table
            var ht = new HashTable<int, string>(10);

            // Act: Search for a key that does not exist
            var result = ht.Search(123);

            // Assert: Ensure the result is null
            Assert.IsNull(result, "Searching for a non-existent key should return null.");
        }
    }
}
