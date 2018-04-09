using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kung_Fu_Tracker.Classes;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Pages
{
    public class HomePage : ContentPage
    {
        
        public HomePage()
        {
            Title = "Kung Fu Tracker";
            ListView lvListView = new ListView();
            lvListView.ItemSelected += LvListView_ItemSelected;
            PopulateHomePage(lvListView);
            Content = new StackLayout
            {
                Children = {
                    lvListView
                }
            };
            
        }

        private void LvListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lvTemp;
            if (sender is ListView)
            {
                lvTemp = sender as ListView;
                NewListPage(lvTemp.SelectedItem.ToString());
                System.Diagnostics.Debug.WriteLine(lvTemp.SelectedItem.ToString());
            }
        }
        private void PopulateHomePage(ListView listView)
        {
            List<string> list = new List<string>();
            list.Add("Patterns");
            list.Add("Combinations");
            list.Add("Applications");
            list.Add("Wrist Locks");
            list.Add("Blocks");
            list.Add("Punches");
            list.Add("Kicks");

            listView.ItemsSource = list;

        }
        private void NewListPage(string name)
        {
            Navigation.PushAsync(new PatternPage(name));
        }
    }
}