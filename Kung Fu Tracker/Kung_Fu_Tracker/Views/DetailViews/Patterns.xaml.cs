using Kung_Fu_Tracker.Classes;
using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Patterns : ContentPage
    {
        List<string> ranks = new List<string>();
        public Patterns()
        {
            InitializeComponent();
            Title = "Patterns";
            //User user = App.UserDatabase.GetUser()
            InitList();
        }
        private void InitList()
        {
            //needs to be replaced by logged in user rank.
            string Rank = "Black";
            int rankID;
            Dictionary<string, int> dictRanks = HelperFunctions.GetRanks();
            if (dictRanks.ContainsKey(Rank))
            {
                rankID = dictRanks[Rank];
                for (int i = 1; i <= rankID; i++)
                {
                    ranks.Add(dictRanks.FirstOrDefault(x => x.Value == i).Key);
                }
            }
            lvPatterns.ItemsSource = ranks;
            lvPatterns.ItemTapped += LvPatterns_ItemTapped;
        }

        private void LvPatterns_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string rank = e.Item.ToString();
            Navigation.PushAsync(new PatternDetails(rank));
            lvPatterns.SelectedItem = null; 
        }
    }
}