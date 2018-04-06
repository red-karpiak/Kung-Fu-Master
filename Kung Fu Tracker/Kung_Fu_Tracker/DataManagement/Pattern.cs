using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Kung_Fu_Tracker.DataManagement
{
    public class Pattern
    {
        [PrimaryKey]
        public string Rank { get; set; }
        public int ID { get; set; }
        public int Order { get; set; }
        public string Feet { get; set; }
        public string Hands { get; set; }
        
        
        public Pattern()
        {

        }
    }
}
