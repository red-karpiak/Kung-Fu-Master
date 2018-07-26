using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Models
{
    /// <summary auth="J.Karpiak" date="26/07/18">
    /// List of common constants like UI design, urls, and stored procedure calls
    /// </summary>
    public class Constants
    {
        public static bool IsDev = true;
        public static Color BackgroundColor = Color.FromHex("E5E5E5");
        public static Color MainTextColor = Color.Black;
        public static Color WhiteTextColor = Color.WhiteSmoke;
        public static Color EntryColor = Color.WhiteSmoke;
        public static Color Red = Color.FromHex("BA0700");
        public static Color Brown = Color.FromHex("3D1003");
        public static Color Blue = Color.FromHex("363CC0");
        public static Color Purple = Color.FromHex("6E0054");
        public static Color Orange = Color.FromHex("F05209");
        public static Color Gold = Color.FromHex("DBB214");
        public static Color White = Color.WhiteSmoke;

        //other colors: 726F72, E9D9D9, 666265

        //Login information
        public static string ipAddress = "192.168.0.97";
        public static string WebUrl = string.Format("http://{0}/Kung_Fu_Tracker.WebService/api/PatternLines", ipAddress);
        
        public static string settingsTitleText = "Settings";

        //API calls to stored procedures in the SQL database
        public static string patternLinePostString = WebUrl + "/?LHand={0}&RHand={1}";
        public static string patternLinePutString = WebUrl + "/{0}?LHand={1}&RHand={2}";
        public static string patternLineDeleteString = WebUrl + "/{0}";
    }
}
