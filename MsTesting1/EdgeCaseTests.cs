using Horizon_Drive_LTD.DataStructure;

namespace MsTesting1
{
    [TestClass]
    public sealed class EdgeCaseTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void Insert_NullKey_ThrowsException()
        {
            // Test Use: Validates that a null key insertion raises a NullReferenceException.
            // Arrange: Initialize the hash table
            var ht = new HashTable<string, string>(10);

            // Act: Attempt to insert a null key
            ht.Insert(null, "Test");

            // Assert: Handled by the ExpectedException attribute
        }

        [TestMethod]
        public void Insert_NullValue_ShouldAllow()
        {
            // Test Use: Confirms that inserting a key with a null value is allowed.
            // Arrange: Initialize the hash table
            var ht = new HashTable<string, string>(10);

            // Act: Insert a key with a null value
            ht.Insert("nullValue", null);
            var result = ht.Search("nullValue");

            // Assert: Verify the value is null as expected
            Assert.IsNull(result, "The value associated with the key should be null.");
        }

        [TestMethod]
        public void Search_EmptyTable_ShouldReturnDefault()
        {
            // Test Use: Ensures searching in an empty hash table returns null.
            // Arrange: Initialize an empty hash table
            var ht = new HashTable<int, string>(10);

            // Act: Search for a key in an empty table
            var result = ht.Search(0);

            // Assert: Verify the result is null
            Assert.IsNull(result, "Searching an empty hash table should return null.");
        }
    }
}
