namespace MsTesting1
{
    [TestClass]
    public sealed class IntegrationTests
    {
        private class MockDatabase
        {
            // Simulated in-memory database to represent user records
            private readonly Dictionary<string, string> _users = new Dictionary<string, string>
            {
                { "tisha@example.com", "Tisha" },
                { "yash@example.com", "Yash" }
            };

            // Method for fetching a user by email
            public string GetUserByEmail(string email)
            {
                return _users.ContainsKey(email) ? _users[email] : null;
            }

            // Method for adding a new user to the database
            public bool AddUser(string username, string email)
            {
                if (!_users.ContainsKey(email))
                {
                    _users[email] = username;
                    return true;
                }
                return false;
            }
        }

        [TestMethod]
        public void FetchData_ShouldReturnRecord_WhenDataExistsInMockDatabase()
        {
            // Test Use: Ensures that a record can be retrieved when it exists in the mock database.
            // Arrange: Initialize the mock database and define expected data
            var mockDatabase = new MockDatabase();
            var email = "tisha@example.com";
            var expectedUsername = "Tisha";

            // Act: Retrieve the user by email
            var actualUsername = mockDatabase.GetUserByEmail(email);

            // Assert: Verify the retrieved username matches the expected username
            Assert.AreEqual(expectedUsername, actualUsername, "The returned username should match the expected record.");
        }

        [TestMethod]
        public void SaveData_ShouldAddRecord_WhenNewDataIsProvided()
        {
            // Test Use: Confirms that a new record is successfully added to the mock database.
            // Arrange: Initialize the mock database and define new user data
            var mockDatabase = new MockDatabase();
            var username = "Khorisha";
            var email = "khorisha@example.com";

            // Act: Add the new user to the database
            var isAdded = mockDatabase.AddUser(username, email);

            // Assert: Ensure the user is added successfully
            Assert.IsTrue(isAdded, "The new user should be added to the database.");
        }
    }
}
