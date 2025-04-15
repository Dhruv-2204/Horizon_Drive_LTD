using System;
using Horizon_Drive_LTD.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting; // MSTest namespace

namespace MSTestHorizonDrive
{
    [TestClass]
    public sealed class InsertTests
    {
        [TestMethod]
        public void Insert_SingleItem_ShouldBeRetrievable()
        {
            // Arrange: Initialize a hash table with a capacity of 10
            var ht = new HashTable<string, int>(10);

            // Act: Insert a single key-value pair
            ht.Insert("one", 1);

            // Assert: Ensure the value can be retrieved correctly
            Assert.AreEqual(1, ht.Search("one"));
        }

        [TestMethod]
        public void Insert_DuplicateKey_ShouldUpdateValue()
        {
            // Arrange: Initialize a hash table with a capacity of 10
            var ht = new HashTable<string, string>(10);

            // Act: Insert a key-value pair and then update the value with the same key
            ht.Insert("username", "khorisha");
            ht.Insert("username", "tisha"); // Update value for the same key

            // Assert: Ensure the updated value is retrievable
            Assert.AreEqual("tisha", ht.Search("username"));
        }
    }
}
