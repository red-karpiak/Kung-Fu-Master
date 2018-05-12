using Kung_Fu_Tracker.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Views.ViewModels
{
    
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
            //replace with user's rank eventually
            string Rank = "Black";
            int rankID;
            Dictionary<string, int> dictRanks = HelperFunctions.GetRanks();
            if (dictRanks.ContainsKey(Rank))
            {
                rankID = dictRanks[Rank];
                for (int i = 1; i <= rankID; i++)
                {
                    RankList.Add(dictRanks.FirstOrDefault(x => x.Value == i).Key);
                }
            }
        }
    }
}
