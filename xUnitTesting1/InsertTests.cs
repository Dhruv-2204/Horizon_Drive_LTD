using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit; 
using Horizon_Drive_LTD.DataStructure; 

namespace HorizonDrive.Tests
{
    public class InsertTests
    {
        [Fact]
        public void Insert_SingleItem_ShouldBeRetrievable()
        {
            // Arrange: Initialize a hash table with a capacity of 10
            var ht = new HashTable<string, int>(10);

            // Act: Insert a single key-value pair
            ht.Insert("one", 1);

            // Assert: Ensure the value can be retrieved correctly
            Assert.Equal(1, ht.Search("one"));
        }

        [Fact]
        public void Insert_DuplicateKey_ShouldUpdateValue()
        {
            // Arrange: Initialize a hash table with a capacity of 10
            var ht = new HashTable<string, string>(10);

            // Act: Insert a key-value pair and then update the value with the same key
            ht.Insert("username", "khorisha");
            ht.Insert("username", "tisha"); // Update value for the same key

            // Assert: Ensure the updated value is retrievable
            Assert.Equal("tisha", ht.Search("username"));
        }
    }
}
