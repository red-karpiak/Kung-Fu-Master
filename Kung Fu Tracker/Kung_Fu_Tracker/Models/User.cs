using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.Models
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string name, string pass)
        {
            Username = name;
            Password = pass;
        }
        public bool CheckInformation()
        {
            if (!this.Username.Equals("") && !this.Password.Equals(""))
                return true;
            else
                return false;
        }
    }
}
