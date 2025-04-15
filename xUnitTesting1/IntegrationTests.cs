using System;
using Xunit;

public class MockDatabase
{
    // Simulated in-memory database as a dictionary
    private readonly Dictionary<string, string> _users = new Dictionary<string, string>
    {
        { "testuser@example.com", "testuser" }
    };

    // Simulated method for fetching a user by email
    public string GetUserByEmail(string email)
    {
        return _users.ContainsKey(email) ? _users[email] : null;
    }

    // Simulated method for adding a new user
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

public class IntegrationTests
{
    [Fact]
    public void FetchData_ShouldReturnRecord_WhenDataExistsInMockDatabase()
    {
        // Arrange
        var mockDatabase = new MockDatabase();
        string email = "testuser@example.com";
        string expectedUsername = "testuser";

        // Act
        string actualUsername = mockDatabase.GetUserByEmail(email);

        // Assert
        Assert.Equal(expectedUsername, actualUsername);
    }

    [Fact]
    public void SaveData_ShouldAddRecord_WhenNewDataIsProvided()
    {
        // Arrange
        var mockDatabase = new MockDatabase();
        string username = "newuser";
        string email = "newuser@example.com";

        // Act
        bool isAdded = mockDatabase.AddUser(username, email);

        // Assert
        Assert.True(isAdded, "The user should be added successfully.");
    }
}
