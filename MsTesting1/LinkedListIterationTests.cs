using Horizon_Drive_LTD;
using System.Linq; // For conversion to a list

namespace MsTesting1
{
    [TestClass]
    public sealed class LinkedListIterationTests
    {
        [TestMethod]
        public void Enumeration_ShouldReturnAllItemsInOrder()
        {
            // Test Use: Verify that the linked list returns all items in the correct order during enumeration.
            // Arrange: Initialize a linked list and add multiple key-value pairs
            var list = new LinkedList<string, string>();
            list.AddLast("101", "Rumaisa");
            list.AddLast("102", "Dhruv");
            list.AddLast("103", "Aayush");

            // Act: Convert the linked list to a collection for enumeration
            var result = list.ToList();

            // Assert: Verify the list contains all items in the correct order
            Assert.AreEqual(3, result.Count, "The count should match the number of added items.");
            Assert.AreEqual("Rumaisa", result[0].Value, "The first item's value should match the expected value.");
            Assert.AreEqual("Dhruv", result[1].Value, "The second item's value should match the expected value.");
            Assert.AreEqual("Aayush", result[2].Value, "The third item's value should match the expected value.");
        }
    }
}
