using Horizon_Drive_LTD;

namespace MsTesting1
{
    [TestClass]
    public sealed class LinkedListFindTests
    {
        [TestMethod]
        public void Find_ExistingKey_ShouldReturnKeyValuePair()
        {
            // Test Use: Validate that searching for an existing key returns the correct key-value pair.
            // Arrange: Initialize the linked list and add a key-value pair
            var list = new LinkedList<string, int>();
            var key = "age"; // Using a relatable key
            var expectedValue = 20; // Representing a realistic value

            list.AddLast(key, expectedValue);

            // Act: Search for the existing key in the linked list
            var result = list.Find(key);

            // Assert: Verify the key-value pair is retrieved correctly
            Assert.IsTrue(result.HasValue, "The key should exist in the linked list.");
            Assert.AreEqual(expectedValue, result.Value.Value, "The value should match the one associated with the key.");
        }

        [TestMethod]
        public void Find_NonExistingKey_ShouldReturnNull()
        {
            // Test Use: Verify that searching for a non-existing key returns null.
            // Arrange: Initialize the linked list and add a single key-value pair
            var list = new LinkedList<string, string>();
            var existingKey = "planet";
            var existingValue = "Mars"; // Using humanized data for realism

            list.AddLast(existingKey, existingValue);

            // Act: Attempt to find a key that doesn't exist
            var result = list.Find("moon"); // Using a key that's not in the list

            // Assert: Ensure the result is null
            Assert.IsNull(result, "Searching for a non-existent key should return null.");
        }
    }
}
