using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace Horizon_Drive_LTD.Domain.Entities
{
    public class User
    {

        public string UserId { get; set; }
        public string Username { get; set; }
        /*
        public string Firstname { get; set; }
        public string Lastname { get; set; }
       
        public int PhoneNum { get; set; }
        public string Address { get; set; }
      
        public DateOnly RegistrationDate { get; set; }
        public string ProfilePicture { get; set; }
        */
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public User(string userid, string username, string password, string role, string email)
        {
            UserId = userid;
            Username = username;
            Password = password;
            Role = role;
            Email = email;
        }

        /*
        public User(string userid, string username, string firstname, string lastname, string email, int phonenum,
            string address, string password, DateOnly registration, string profilepic)
        {
            UserId = userid;
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
            Email = email;
            PhoneNum = phonenum;
            Address = address;
            RegistrationDate = registration;
            ProfilePicture = profilepic;
        }

        */
    }
}

