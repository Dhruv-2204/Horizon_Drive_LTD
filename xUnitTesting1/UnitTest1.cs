using Xunit;
using Horizon_Drive_LTD;
using Horizon_Drive_LTD.DataStructure;
using System.Collections.Generic;

namespace xUnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public void InsertAndSearch_ReturnsCorrectValue()
        {
            var table = new HashTable<string, string>(5);
            table.Insert("username", "tisha123");

            var result = table.Search("username");

            Assert.Equal("tisha123", result);
        }

        [Fact]
        public void Insert_OverwritesExistingKey()
        {
            var table = new HashTable<string, string>(5);
            table.Insert("username", "tisha123");
            table.Insert("username", "newTisha");

            var result = table.Search("username");

            Assert.Equal("newTisha", result);
        }

        [Fact]
        public void Search_ReturnsDefaultForMissingKey()
        {
            var table = new HashTable<string, string>(5);
            table.Insert("username", "tisha123");

            var result = table.Search("missing");

            Assert.Null(result); // default for string is null
        }

        [Fact]
        public void Remove_DeletesKeyAndReturnsTrue()
        {
            var table = new HashTable<string, string>(5);
            table.Insert("username", "tisha123");

            var removed = table.Remove("username");
            var result = table.Search("username");

            Assert.True(removed);
            Assert.Null(result);
        }

        [Fact]
        public void Remove_ReturnsFalseWhenKeyNotFound()
        {
            var table = new HashTable<string, string>(5);

            var removed = table.Remove("missing");

            Assert.False(removed);
        }

        [Fact]
        public void GetAllItems_ReturnsAllInsertedItems()
        {
            var table = new HashTable<string, string>(5);
            table.Insert("a", "apple");
            table.Insert("b", "banana");
            table.Insert("c", "cherry");

            var items = new List<KeyValuePair<string, string>>(table.GetAllItems());

            Assert.Contains(new KeyValuePair<string, string>("a", "apple"), items);
            Assert.Contains(new KeyValuePair<string, string>("b", "banana"), items);
            Assert.Contains(new KeyValuePair<string, string>("c", "cherry"), items);
        }
    }
}
