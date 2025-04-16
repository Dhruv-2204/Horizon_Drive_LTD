namespace Horizon_Drive_LTD.Domain.Entities
{
    // This class represents a user in the car rental system.
    public class User
    {

        public string UserId { get; set; }
        public string UserName { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Email { get; set; }
        public int TelephoneNo { get; set; }
        
        public string Address { get; set; }
        public string Password { get; set; }
        public DateOnly DOB { get; set; }

        public string ProfilePicture { get; set; }

        //  Constructor to initialize a user object
        public User(string userid, string username, string firstname, string lastname, string email, int phonenum,
            string address, string password, DateOnly dob, string profilepic)
        {
            UserId = userid;
            UserName = username;
            FirstName = firstname;
            LastName = lastname;
            Password = password;
            Email = email;
            TelephoneNo = phonenum;
            Address = address;
            DOB = dob;
            ProfilePicture = profilepic;
        }

        
    }
}

