using Horizon_Drive_LTD;

namespace MsTesting1
{
    [TestClass]
    public sealed class LinkedListEdgeCaseTests
    {
        [TestMethod]
        public void Find_EmptyList_ShouldReturnNull()
        {
            // Test Use: Ensure finding a key in an empty linked list returns null.
            // Arrange: Initialize an empty linked list
            var list = new LinkedList<int, string>();

            // Act: Attempt to find a key that hasn't been added
            var result = list.Find(101); // Using an arbitrary key that doesn't exist

            // Assert: Verify the result is null as expected
            Assert.IsNull(result, "The result should be null when the key is not found in the list.");
        }

        [TestMethod]
        public void Remove_EmptyList_ShouldReturnFalse()
        {
            // Test Use: Verify that removing a key from an empty linked list returns false.
            // Arrange: Initialize an empty linked list
            var list = new LinkedList<int, string>();

            // Act: Attempt to remove a key from the empty list
            var isRemoved = list.Remove(202); // Using an arbitrary key that doesn't exist

            // Assert: Confirm the operation returns false
            Assert.IsFalse(isRemoved, "Removing a key from an empty list should return false.");
        }
    }
}
