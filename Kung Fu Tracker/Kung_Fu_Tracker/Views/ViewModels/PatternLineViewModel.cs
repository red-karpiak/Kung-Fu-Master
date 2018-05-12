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
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public PatternLine Line { get; set; }
        public string Rank { get; set; }
        
        public PatternLineViewModel(PatternLine patternLine)
        {
            Rank = patternLine.Rank;
            Line = patternLine;
            Init();
        }
        private void Init()
        {
            TextMargin = new Thickness(10, 0, 0, 0);

            SaveCommand = new Command(OnSaveCommand);
            CancelCommand = new Command(OnCancelCommand);
        }

        public void OnSaveCommand()
        {
            //need to make a call to the sql connection to modify/insert the line
            
        }
        public void OnCancelCommand()
        {
            //don't save
        }
    }
}
