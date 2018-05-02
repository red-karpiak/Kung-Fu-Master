using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Views.ViewModels
{
    public class PatternLineViewModel
    {
        public Thickness TextMargin { get; set; }
        public ICommand ModifyOrInsert { get; set; }
        public Pattern Pattern { get; set; }
        public string Rank { get; set; }
        
        public PatternLineViewModel(string rank)
        {
            Rank = rank;
            Init();
        }
        public PatternLineViewModel(Pattern pattern)
        {
            Pattern = pattern;
            Init();
        }
        private void Init()
        {
            if (Pattern == null)
            {
                Pattern = new Pattern
                {
                    Rank = Rank
                };
            }
            TextMargin = new Thickness(10, 0, 0, 0);

            ModifyOrInsert = new Command(OnModifyOrInsert);
        }
        public void OnModifyOrInsert()
        {
            //need to make a call to the sql connection to modify/insert the line
            
        }
    }
}
