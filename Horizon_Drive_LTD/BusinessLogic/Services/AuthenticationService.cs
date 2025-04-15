using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;



namespace Horizon_Drive_LTD.BusinessLogic.Services
{
    /// AuthenticationService is a class that handles user authentication
    public class AuthenticationService
    {
        private HashTable<string, User> userHashTable;
        private UserRepository _userRepo;

        /// Constructor for AuthenticationService
        public AuthenticationService(HashTable<string, User> hashTable, UserRepository userRepo)
        {
            userHashTable = hashTable;
            //customerHashTable = hashTable;
            _userRepo = userRepo;
        }

        /// Login method checks if the user exists in the hash table and verifies the password
        public bool Login(string username, string password, out User loggedInUser)
        {
            loggedInUser = null;

            foreach (var kvp in userHashTable.GetAllItems())
            {
                if (kvp.Value.UserName == username && kvp.Value.Password == password)
                {
                    loggedInUser = kvp.Value;
                    return true;
                }
            }

            return false;
        }

        /// SignUp method checks if the user already exists and adds a new user to the hash table
        public bool SignUp(User newUser)
        {
            var existingUser = userHashTable.Search(newUser.UserName);
            if (existingUser != null)
            {

                return false;
            }

            userHashTable.Insert(newUser.UserId, newUser);
            
            _userRepo.InsertUser(newUser);


            return true;
        }
    }
}
