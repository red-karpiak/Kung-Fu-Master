using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Kung_Fu_Tracker.DataManagement
{
    public class PatternEntry
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Rank { get; set; }
        public string legMovement { get; set; }
        public string handMovement { get; set; }
        public PatternEntry()
        {

        }
    }
}
