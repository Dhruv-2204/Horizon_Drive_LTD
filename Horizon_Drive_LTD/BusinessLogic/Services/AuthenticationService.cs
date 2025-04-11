using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;



namespace Horizon_Drive_LTD.BusinessLogic.Services
{
    public class AuthenticationService
    {
        private HashTable<string, User> userHashTable;
        private UserRepository _userRepo;

        public AuthenticationService(HashTable<string, User> hashTable, UserRepository userRepo)
        {
            userHashTable = hashTable;
            _userRepo = userRepo;
        }


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
