using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit; // For unit testing framework
using Horizon_Drive_LTD.DataStructure; // For the HashTable class

namespace HorizonDrive.Tests
{
    public class ResizeTests
    {
        [Fact]
        public void Insert_MultipleItems_ShouldTriggerResize()
        {
            // Arrange: Create a hash table with a small initial capacity to trigger resizing.
            var ht = new HashTable<int, string>(3);

            // Act: Insert multiple key-value pairs into the hash table.
            for (int i = 0; i < 10; i++)
            {
                ht.Insert(i, $"Value{i}");
            }

            // Assert: Ensure all key-value pairs can still be retrieved after resizing.
            for (int i = 0; i < 10; i++)
            {
                Assert.Equal($"Value{i}", ht.Search(i));
            }
        }
    }
}
