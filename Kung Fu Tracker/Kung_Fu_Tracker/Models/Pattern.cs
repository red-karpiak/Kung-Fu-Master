using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Kung_Fu_Tracker.Models
{
    public class Pattern
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Rank { get; set; }
        public int Order { get; set; }
        public string Feet { get; set; }
        public string Hands { get; set; }

        public Pattern() { }
        public Pattern(string rank, int order, string feet, string hands)
        {
            Rank = rank;
            Order = order;
            Feet = feet;
            Hands = hands;
        }
    }
}
