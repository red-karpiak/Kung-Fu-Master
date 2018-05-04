using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kung_Fu_Tracker.Models
{
    public class PatternLine
    {
        //by the simple fact that it is called "Id", the Entity Framework knows it will be the primary key
        public int Id { get; set; }
        public string Rank { get; set; }
        public int Order { get; set; }
        public string Feet { get; set; }
        public string Hands { get; set; }
        public PatternLine(string rank, int order, string feet, string hands)
        {
            Rank = rank;
            Order = order;
            Feet = feet;
            Hands = hands;
        }

    }
}
