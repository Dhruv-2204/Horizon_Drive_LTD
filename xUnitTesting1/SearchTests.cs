using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit; // For unit testing framework
using Horizon_Drive_LTD.DataStructure; // For the HashTable class

namespace HorizonDrive.Tests
{
    public class SearchTests
    {
        [Fact]
        public void Search_ExistingKey_ReturnsCorrectValue()
        {
            // Arrange: Initialize a hash table with a capacity of 10
            var ht = new HashTable<int, string>(10);

            // Act: Insert a key-value pair
            ht.Insert(99, "Mauritius");

            // Assert: Verify the value associated with the existing key
            Assert.Equal("Mauritius", ht.Search(99));
        }

        [Fact]
        public void Search_NonExistentKey_ReturnsDefault()
        {
            // Arrange: Initialize a hash table with a capacity of 10
            var ht = new HashTable<int, string>(10);

            // Act & Assert: Verify that searching for a nonexistent key returns the default value (null)
            Assert.Null(ht.Search(123));
        }
    }
}
