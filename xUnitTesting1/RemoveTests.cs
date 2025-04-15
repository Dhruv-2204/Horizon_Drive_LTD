using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit; // For unit testing framework
using Horizon_Drive_LTD.DataStructure; // For the HashTable class

namespace HorizonDrive.Tests
{
    public class RemoveTests
    {
        [Fact]
        public void Remove_ExistingKey_ShouldReturnTrue()
        {
            // Arrange: Initialize a hash table with a capacity of 10 and insert a key-value pair.
            var ht = new HashTable<string, int>(10);
            ht.Insert("k", 100);

            // Act & Assert: Verify that the key is removed successfully.
            Assert.True(ht.Remove("k"));
        }

        [Fact]
        public void Remove_NonExistingKey_ShouldReturnFalse()
        {
            // Arrange: Initialize a hash table with a capacity of 10.
            var ht = new HashTable<string, int>(10);

            // Act & Assert: Verify that attempting to remove a nonexistent key returns false.
            Assert.False(ht.Remove("unknown"));
        }

        [Fact]
        public void Remove_ThenSearch_ShouldReturnDefault()
        {
            // Arrange: Initialize a hash table with a capacity of 10 and insert a key-value pair.
            var ht = new HashTable<string, string>(10);
            ht.Insert("car", "BMW");

            // Act: Remove the key-value pair.
            ht.Remove("car");

            // Assert: Verify that searching for the removed key returns the default value (null).
            Assert.Null(ht.Search("car"));
        }
    }
}
