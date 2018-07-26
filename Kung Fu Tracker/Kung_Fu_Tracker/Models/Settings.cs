
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Models
{
    /// <summary auth="J.Karpiak" date="26/07/18">
    /// A basic settings entry into the database. This data currently does nothing. Just a place holder
    /// 
    /// I probably should have just left this out until i needed to implement it. But yet another instance of where
    /// I should have a base DataItem class 
    /// </summary>
    public class Settings
    {
        public int ID { get; set; }
        public bool Switch1 { get; set; }
        public bool Switch2 { get; set; }
        public string Password { get; set; }
    }
}
