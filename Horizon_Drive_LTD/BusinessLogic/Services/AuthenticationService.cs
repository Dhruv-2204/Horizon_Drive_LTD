using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;



namespace Horizon_Drive_LTD.BusinessLogic.Services
{
    public class AuthenticationService
    {
        private HashTable<string, User> userHashTable;


        public AuthenticationService(HashTable<string, User> hashTable)
        {
            userHashTable = hashTable;
        }


        public bool Login(string username, string password, out User loggedInUser)
        {
            loggedInUser = null;

            foreach (var kvp in userHashTable.GetAllItems())
            {
                if (kvp.Value.Username == username && kvp.Value.Password == password)
                {
                    loggedInUser = kvp.Value;
                    return true;
                }
            }

            return false;
        }

        public bool SignUp(User newUser)
        {
            var existingUser = userHashTable.Search(newUser.Username);
            if (existingUser != null)
            {
             
                return false;
            }

            userHashTable.Insert(newUser.UserId, newUser);

            
            return true;
        }
    }
}
