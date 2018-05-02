using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.Models
{
    public class User
    {
        //Entity framework assumes that the Id is the primary key simply by calling it "Id"
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rank { get; set; }
        public int Stripes { get; set; }

        public User() { }
        public User(string name, string pass)
        {
            Username = name;
            Password = pass;
            Rank = "Purple";
            Stripes = 0;
        }
        public bool CheckInformation()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                return false;
            else
                return true;
        }
    }
}
