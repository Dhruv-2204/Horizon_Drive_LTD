using System;
using Xunit; // For unit testing framework
using Horizon_Drive_LTD.DataStructure; // For the HashTable class

namespace HorizonDrive.Tests
{
    public class EdgeCaseTests
    {
        [Fact]
        public void Insert_NullKey_ThrowsException()
        {
            // Arrange: Initialize the hash table
            var ht = new HashTable<string, string>(10);

            // Act & Assert: Verify that inserting a null key throws a NullReferenceException
            Assert.Throws<System.NullReferenceException>(() => ht.Insert(null, "Test"));
        }

        [Fact]
        public void Insert_NullValue_ShouldAllow()
        {
            // Arrange: Initialize the hash table
            var ht = new HashTable<string, string>(10);

            // Act: Insert a key with a null value
            ht.Insert("nullValue", null);

            // Assert: Verify that the null value can be searched and retrieved correctly
            Assert.Null(ht.Search("nullValue"));
        }

        [Fact]
        public void Search_EmptyTable_ShouldReturnDefault()
        {
            // Arrange: Initialize an empty hash table
            var ht = new HashTable<int, string>(10);

            // Act & Assert: Verify that searching for a key in an empty table returns null
            Assert.Null(ht.Search(0));
        }
    }
}
