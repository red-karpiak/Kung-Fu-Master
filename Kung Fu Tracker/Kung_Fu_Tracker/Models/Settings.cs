using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Models
{
    public class Settings
    {
        [PrimaryKey]
        public int ID { get; set; }
        public bool switch1 { get; set; }
        public bool switch2 { get; set; }
    }
}
