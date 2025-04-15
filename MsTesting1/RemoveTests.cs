using Horizon_Drive_LTD.DataStructure;

namespace MsTesting1
{
    [TestClass]
    public sealed class RemoveTests
    {
        [TestMethod]
        public void Remove_ExistingCar_ShouldReturnTrue()
        {
            // Test Use: Verify that an existing car can be removed successfully.
            // Arrange: Initialize a hash table and add a car
            var ht = new HashTable<string, string>(10);
            ht.Insert("car", "Toyota");

            // Act: Attempt to remove the car
            var isRemoved = ht.Remove("car");

            // Assert: Ensure the car is removed successfully
            Assert.IsTrue(isRemoved, "The car 'Toyota' should be removed from the hash table.");
        }

        [TestMethod]
        public void Remove_NonExistingCar_ShouldReturnFalse()
        {
            // Test Use: Verify that attempting to remove a non-existent car returns false.
            // Arrange: Initialize an empty hash table
            var ht = new HashTable<string, string>(10);

            // Act: Attempt to remove a car that doesn't exist
            var isRemoved = ht.Remove("car");

            // Assert: Confirm the removal operation fails
            Assert.IsFalse(isRemoved, "Attempting to remove a non-existent car should return false.");
        }

        [TestMethod]
        public void Remove_ThenSearchCar_ShouldReturnDefault()
        {
            // Test Use: Verify that searching for a removed car returns the default value (null).
            // Arrange: Initialize a hash table and add a car
            var ht = new HashTable<string, string>(10);
            ht.Insert("car", "Ford");

            // Act: Remove the car
            ht.Remove("car");

            // Assert: Ensure the removed car no longer exists
            Assert.IsNull(ht.Search("car"), "Searching for a removed car should return null.");
        }
    }
}
