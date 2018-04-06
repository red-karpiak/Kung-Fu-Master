using Kung_Fu_Tracker.DataManagement;
using Kung_Fu_Tracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kung_Fu_Tracker.Pages
{
    public class ListPage : ContentPage
    {
        public Entry footPattern = new Entry();
        public Entry handPattern = new Entry();
        public Entry rank = new Entry();
        public Entry stepID = new Entry();
        public int StepID;
        public Pattern PatternEntry;
        public Button submit = new Button();
        public ListPage(string pageName)
        {
            Title = pageName;
            submit.Text = "Toast!";
            submit.Clicked += Submit_Clicked;
            //get page type by name
            Content = new StackLayout
            {
                
                Children = {
                    new Label { Text = "foot: " },
                    footPattern,
                    new Label { Text = "hand: " },
                    handPattern,
                    new Label { Text = "rank: " },
                    rank,
                    new Label { Text = "order: " },
                    stepID,
                    submit
                }
            };
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(stepID.Text, out StepID);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            
            List<string> messages = new List<string> { stepID.Text, footPattern.Text, handPattern.Text, rank.Text };

            DependencyService.Get<IUIElements>().toast(messages);
            footPattern.Text = "";
            handPattern.Text = "";
            rank.Text = "";
            stepID.Text = "";
        }
    }
}