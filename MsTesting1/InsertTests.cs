using Horizon_Drive_LTD.DataStructure;

namespace MsTesting1
{
    [TestClass]
    public sealed class InsertTests
    {
        [TestMethod]
        public void Insert_SingleItem_ShouldBeRetrievable()
        {
            // Test Use: Verify that a single item inserted into the hash table can be retrieved correctly.
            // Arrange: Initialize a hash table with a capacity of 10
            var ht = new HashTable<string, int>(10);
            var key = "one";
            var expectedValue = 1;

            // Act: Insert a single key-value pair and retrieve the value
            ht.Insert(key, expectedValue);
            var result = ht.Search(key);

            // Assert: Ensure the value matches the expected result
            Assert.AreEqual(expectedValue, result, "The value should be retrievable and match the inserted value.");
        }

        [TestMethod]
        public void Insert_DuplicateKey_ShouldUpdateValue()
        {
            // Test Use: Verify that inserting a duplicate key updates the existing value in the hash table.
            // Arrange: Initialize a hash table with a capacity of 10
            var ht = new HashTable<string, string>(10);
            var key = "username";
            var initialValue = "khorisha";
            var updatedValue = "tisha";

            // Act: Insert a key-value pair, then update it with a new value
            ht.Insert(key, initialValue);
            ht.Insert(key, updatedValue);
            var result = ht.Search(key);

            // Assert: Ensure the updated value is retrievable and matches the latest value
            Assert.AreEqual(updatedValue, result, "The value should be updated and retrievable.");
        }
    }
}
