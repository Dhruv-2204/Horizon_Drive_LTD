using System;
using System.Collections.Generic;
using Xunit; // For unit testing framework
using Horizon_Drive_LTD; // For the LinkedList class
using System.Linq; // For conversion to list

namespace HorizonDrive.Tests
{
    public class LinkedListIterationTests
    {
        [Fact]
        public void Enumeration_ShouldReturnAllItemsInOrder()
        {
            // Arrange: Create a linked list and add multiple key-value pairs
            var list = new LinkedList<string, string>();
            list.AddLast("1", "One");
            list.AddLast("2", "Two");
            list.AddLast("3", "Three");

            // Act: Convert the linked list to a list for enumeration
            var result = list.ToList();

            // Assert: Verify the list contains all items in the correct order
            Assert.Equal(3, result.Count); // Ensure the count matches the added items
            Assert.Equal("One", result[0].Value); // Verify the first item's value
            Assert.Equal("Two", result[1].Value); // Verify the second item's value
            Assert.Equal("Three", result[2].Value); // Verify the third item's value
        }
    }
}
