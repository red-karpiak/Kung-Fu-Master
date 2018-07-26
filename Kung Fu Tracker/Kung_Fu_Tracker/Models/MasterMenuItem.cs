using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Models
{
    /// <summary auth="J.Karpiak" date="26/07/18">
    /// The menu items in the side panel for toggling through different pages.
    /// I would like to make this inherit from an abstract "MenuItem" class, that way in the future when I need different
    /// menu items in other pages so I don't have to repeat code
    /// </summary>
    public class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Color BackgroundColor { get; set; }
        public Type TargetType { get; set; }

        public MasterMenuItem(string title, string iconSource, Color backColor, Type targetType)
        {
            Title = title;
            IconSource = iconSource;
            BackgroundColor = backColor;
            TargetType = targetType;
        }
    }
}
