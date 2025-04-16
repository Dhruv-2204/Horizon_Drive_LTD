using Horizon_Drive_LTD;

namespace MsTesting1
{
    [TestClass]
    public sealed class LinkedListAddTests
    {
        [TestMethod]
        public void AddLast_SingleItem_ShouldBeRetrievable()
        {
            // Test Use: Verify if a single item added to the linked list can be successfully retrieved.
            // Arrange: Create a LinkedList instance
            var list = new LinkedList<string, int>();
            var key = "key1";
            var value = 100;

            // Act: Add a key-value pair to the list
            list.AddLast(key, value);
            var result = list.Find(key);

            // Assert: Check if the item exists and the value matches
            Assert.IsTrue(result.HasValue, "The item should exist in the linked list.");
            Assert.AreEqual(value, result.Value.Value, "The value should match the expected result.");
        }

        [TestMethod]
        public void AddLast_MultipleItems_ShouldMaintainOrder()
        {
            // Test Use: Verify if multiple items added maintain their insertion order.
            // Arrange: Create a LinkedList instance
            var list = new LinkedList<string, string>();
            var firstKey = "keyA";
            var firstValue = "Value1";
            var secondKey = "keyB";
            var secondValue = "Value2";

            // Act: Add multiple key-value pairs
            list.AddLast(firstKey, firstValue);
            list.AddLast(secondKey, secondValue);
            var result = list.ToList();

            // Assert: Confirm order and values
            Assert.AreEqual(2, result.Count, "The count should match the number of added items.");
            Assert.AreEqual(firstValue, result[0].Value, "The first item's value should match.");
            Assert.AreEqual(secondValue, result[1].Value, "The second item's value should match.");
        }
    }
}
