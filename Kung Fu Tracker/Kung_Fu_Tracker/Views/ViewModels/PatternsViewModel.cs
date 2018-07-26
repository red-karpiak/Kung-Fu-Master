using Kung_Fu_Tracker.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Views.ViewModels
{
    /// <summary>
    /// View model for the Pattern page
    /// </summary>
    public class PatternsViewModel
    {
        public List<string> RankList { get; set; }
        private string selectedItem;
        public string SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    MessagingCenter.Send(this, "Pattern", selectedItem);
                    SelectedItem = null;
                }
            }
        }
        public PatternsViewModel()
        {
            InitList();
        }
        private void InitList()
        {
            RankList = new List<string>();
            //eventually i would replace his with the user's rank so that only their curriculum would show
            //e.g. LoggedInUser.Rank
            string Rank = "Black";
            int rankID;
            Dictionary<string, int> dictRanks = HelperFunctions.GetRanks();
            if (dictRanks.ContainsKey(Rank))
            {
                //this will only add patterns up to and including the User's current rank
                rankID = dictRanks[Rank];
                for (int i = 1; i <= rankID; i++)
                {
                    RankList.Add(dictRanks.FirstOrDefault(x => x.Value == i).Key);
                }
            }
        }
    }
}
