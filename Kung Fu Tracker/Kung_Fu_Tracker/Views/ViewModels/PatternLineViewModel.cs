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
    /// <summary auth="J.Karpiak" date="26/07/18">
    /// The business logic for the Pattern Line page. Saving new or modified pattern lines
    /// </summary>
    public class PatternLineViewModel
    {
        public Thickness TextMargin { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public PatternLine Line { get; set; }
        public string Rank { get; set; }
        bool isNewLine { get; set; }
        
        public PatternLineViewModel(PatternLine patternLine)
        {
            Rank = patternLine.Rank;
            if (patternLine.Order == 0)
                isNewLine = true;
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
            if (Line.Order < 1)
                MessagingCenter.Send(this, "Error", "Order cannot be less than 1");
            else if (string.IsNullOrEmpty(Line.Feet))
                MessagingCenter.Send(this, "Error", "You must supply a value for Feet");
            else if (string.IsNullOrEmpty(Line.LeftHand))
                MessagingCenter.Send(this, "Error", "You must supply a value for Left Hand");
            else if (string.IsNullOrEmpty(Line.RightHand))
                MessagingCenter.Send(this, "Error", "You must supply a value for Right Hand");
            else
            {
                SaveLine();
                MessagingCenter.Send(this, "Close");
            }
        }
        public void OnCancelCommand()
        {
            MessagingCenter.Send(this, "Close");
        }
        private async void SaveLine()
        {
            await App.restService.SavePatternLine(Line, isNewLine);
        }
    }
}
