using System;
using System.Collections.Generic;
using Xunit; // For unit testing framework
using Horizon_Drive_LTD; // For the LinkedList class

namespace HorizonDrive.Tests
{
    public class LinkedListAddTests
    {
        [Fact]
        public void AddLast_SingleItem_ShouldBeRetrievable()
        {
            // Arrange: Create a new LinkedList instance
            var list = new LinkedList<string, int>();

            // Act: Add a single key-value pair to the list
            list.AddLast("key1", 10);

            // Assert: Find the added item and ensure it is retrievable
            var result = list.Find("key1");
            Assert.True(result.HasValue); // Verify the item exists
            Assert.Equal(10, result.Value.Value); // Verify the value matches
        }

        [Fact]
        public void AddLast_MultipleItems_ShouldMaintainOrder()
        {
            // Arrange: Create a new LinkedList instance
            var list = new LinkedList<string, string>();

            // Act: Add multiple key-value pairs to the list
            list.AddLast("first", "A");
            list.AddLast("second", "B");

            // Assert: Convert the linked list to a collection and verify order
            var result = list.ToList();
            Assert.Equal(2, result.Count); // Verify the count matches the number of added items
            Assert.Equal("A", result[0].Value); // Verify the first item's value
            Assert.Equal("B", result[1].Value); // Verify the second item's value
        }
    }
}
