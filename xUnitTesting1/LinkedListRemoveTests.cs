using System;
using System.Collections.Generic;
using Xunit; // For unit testing framework
using Horizon_Drive_LTD; // For the LinkedList class

namespace HorizonDrive.Tests
{
    public class LinkedListRemoveTests
    {
        [Fact]
        public void Remove_HeadNode_ShouldUpdateHead()
        {
            // Arrange: Create a linked list and add two items
            var list = new LinkedList<string, int>();
            list.AddLast("head", 1);
            list.AddLast("tail", 2);

            // Act: Remove the head node
            var removed = list.Remove("head");

            // Assert: Verify removal and updated head
            Assert.True(removed); // Confirm that the node was removed
            Assert.Null(list.Find("head")); // Confirm the removed node is no longer in the list
            Assert.Equal("tail", list.ToList().First().Key); // Ensure the new head is the next node
        }

        [Fact]
        public void Remove_MiddleOrLastNode_ShouldSucceed()
        {
            // Arrange: Create a linked list and add three items
            var list = new LinkedList<int, string>();
            list.AddLast(1, "A");
            list.AddLast(2, "B");
            list.AddLast(3, "C");

            // Act: Remove the middle node
            Assert.True(list.Remove(2));

            // Assert: Verify removal and remaining nodes
            Assert.Null(list.Find(2)); // Confirm the removed node is no longer in the list
            Assert.Equal(2, list.ToList().Count); // Ensure the count matches after removal
        }

        [Fact]
        public void Remove_NonExistentNode_ShouldReturnFalse()
        {
            // Arrange: Create a linked list and add a single item
            var list = new LinkedList<int, string>();
            list.AddLast(1, "Test");

            // Act & Assert: Attempt to remove a non-existent node and verify the result
            Assert.False(list.Remove(99)); // Ensure removal fails for a non-existent key
        }
    }
}
