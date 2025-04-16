using System;
using System.Collections.Generic;
using Xunit; // For unit testing framework
using Horizon_Drive_LTD; // For the LinkedList class

namespace HorizonDrive.Tests
{
    public class LinkedListFindTests
    {
        [Fact]
        public void Find_ExistingKey_ShouldReturnKeyValuePair()
        {
            // Arrange: Create a linked list and add a key-value pair
            var list = new LinkedList<string, int>();
            list.AddLast("age", 20);

            // Act: Search for the existing key
            var result = list.Find("age");

            // Assert: Verify the key-value pair is found correctly
            Assert.True(result.HasValue); // Ensure the item exists
            Assert.Equal(20, result.Value.Value); // Check the value matches
        }

        [Fact]
        public void Find_NonExistingKey_ShouldReturnNull()
        {
            // Arrange: Create a linked list and add a single key-value pair
            var list = new LinkedList<string, string>();
            list.AddLast("planet", "Mars");

            // Act: Search for a non-existent key
            var result = list.Find("moon");

            // Assert: Verify the result is null
            Assert.Null(result); // Ensure no value is returned for a missing key
        }
    }
}
