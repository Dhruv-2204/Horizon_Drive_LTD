using System;
using Xunit; // For unit testing framework
using Horizon_Drive_LTD; // For the LinkedList class

namespace HorizonDrive.Tests
{
    public class LinkedListEdgeCaseTests
    {
        [Fact]
        public void Find_EmptyList_ShouldReturnNull()
        {
            // Arrange: Create an empty linked list
            var list = new LinkedList<int, string>();

            // Act: Attempt to find a key in the empty list
            var result = list.Find(1);

            // Assert: Verify that the result is null
            Assert.Null(result);
        }

        [Fact]
        public void Remove_EmptyList_ShouldReturnFalse()
        {
            // Arrange: Create an empty linked list
            var list = new LinkedList<int, string>();

            // Act & Assert: Verify that removing a key from the empty list returns false
            Assert.False(list.Remove(5));
        }          
    }
}
