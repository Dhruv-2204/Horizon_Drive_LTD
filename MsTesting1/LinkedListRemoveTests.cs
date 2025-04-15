using Horizon_Drive_LTD;

namespace MsTesting1
{
    [TestClass]
    public sealed class LinkedListRemoveTests
    {
        [TestMethod]
        public void Remove_HeadNode_ShouldUpdateHead()
        {
            // Test Use: Verify that removing the head node updates the head of the linked list.
            // Arrange: Initialize a linked list and add two items
            var list = new LinkedList<string, int>();
            list.AddLast("firstNode", 1); // Adding the head node
            list.AddLast("secondNode", 2); // Adding the tail node

            // Act: Remove the head node
            var removed = list.Remove("firstNode");

            // Assert: Confirm removal and head update
            Assert.IsTrue(removed, "The head node should be removed successfully.");
            Assert.IsNull(list.Find("firstNode"), "The removed node should no longer exist in the list.");
            Assert.AreEqual("secondNode", list.ToList().First().Key, "The new head should be the second node.");
        }

        [TestMethod]
        public void Remove_MiddleOrLastNode_ShouldSucceed()
        {
            // Test Use: Ensure that removing a middle or last node from the linked list works correctly.
            // Arrange: Initialize a linked list and add three items
            var list = new LinkedList<int, string>();
            list.AddLast(1, "Rumaisa"); // First node
            list.AddLast(2, "Dhruv");   // Middle node
            list.AddLast(3, "Aayush");  // Last node

            // Act: Remove the middle node
            var removed = list.Remove(2);

            // Assert: Verify removal and remaining nodes
            Assert.IsTrue(removed, "The middle node should be removed successfully.");
            Assert.IsNull(list.Find(2), "The removed node should no longer exist in the list.");
            Assert.AreEqual(2, list.ToList().Count, "The list should contain the correct number of nodes after removal.");
        }

        [TestMethod]
        public void Remove_NonExistentNode_ShouldReturnFalse()
        {
            // Test Use: Verify that attempting to remove a non-existent node returns false.
            // Arrange: Initialize a linked list and add a single item
            var list = new LinkedList<int, string>();
            list.AddLast(1, "HorizonDrive"); // Adding one node

            // Act: Attempt to remove a node that doesn't exist
            var removed = list.Remove(99); // Non-existent key

            // Assert: Ensure the operation fails for the non-existent node
            Assert.IsFalse(removed, "Attempting to remove a non-existent node should return false.");
        }
    }
}
