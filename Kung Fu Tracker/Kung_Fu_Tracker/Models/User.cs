﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.Models
{
    public class User
    {
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
        }
        public User(string name, string pass, string rank, byte stripes)
        {
            Username = name;
            Password = pass;
            Rank = rank;
            Stripes = stripes;
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
