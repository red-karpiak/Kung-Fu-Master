﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Classes
{
    /// <comment auth="J.Karpiak" date="26/07/18">
    /// Static class to avoid code rewrites
    /// </comment>
    public static class HelperFunctions
    {
        /// <summary>
        /// The basic belt levels never change, so making a REST call to pull them from a table in the database only so they can be
        /// displayed in the UI seems unnecessary.
        /// </summary>
        public static Dictionary<string, int> GetRanks()
        {
            Dictionary<string, int> ranks = new Dictionary<string, int>();
            ranks.Add("White", 1);
            ranks.Add("Gold", 2);
            ranks.Add("Orange", 3);
            ranks.Add("Purple", 4);
            ranks.Add("Blue", 5);
            ranks.Add("Brown 3", 6);
            ranks.Add("Brown 2", 7);
            ranks.Add("Brown 1", 8);
            ranks.Add("Red", 9);
            ranks.Add("Black", 10);

            return ranks;
        }
    }
}
