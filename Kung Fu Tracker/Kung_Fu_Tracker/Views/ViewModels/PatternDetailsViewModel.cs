using Kung_Fu_Tracker.DataManagement;
using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.DetailViews;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Views.ViewModels
{
    public class PatternDetailsViewModel : INotifyPropertyChanged
    {

        public string Rank { get; set; }
        private List<PatternLine> patternLines;
        private List<PatternLine> rankLines;
        public List<PatternLine> RankLines
        {
            get { return rankLines; }
            set
            {
                rankLines = value;
                OnPropertyChanged();
            }
        }
        public PatternLine SelectedItem { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public bool IsRefreshing { get; set; }
        public string content { get; set; }
        
        public PatternDetailsViewModel(string rank)
        {
            Rank = rank;
            InitGrid(Rank);

            RefreshCommand = new Command(OnRefreshCommand);
            DeleteCommand = new Command(OnDeleteCommand);
            NewCommand = new Command(OnNewCommand);
            CancelCommand = new Command(OnCancelCommand);
            EditCommand = new Command(OnEditCommand);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //private async void InitGrid(string rank)
        private void InitGrid(string rank)
        {
            //content = await App.restService.GetData();
            //System.Diagnostics.Debug.WriteLine("\n\n\nContent:" + content + "\n\n\n");
            //patternLines = JsonConvert.DeserializeObject<List<PatternLine>>(content);
            //var lines =  from line in patternLines where line.Rank.Equals(Rank) select line;
            //System.Diagnostics.Debug.WriteLine("\n\n\n Type: " + lines.GetType() + "\n\n\n");
            //RankLines = lines.ToList();
            patternLines = new List<PatternLine>
            {
                new PatternLine("White", 1, "W, L Frt Stn", "W, Low Blk", "W, Chamber"),
                new PatternLine("White", 2, "W, R Frt Stn", "W, Chamber", "W, Frt Punch"),
                new PatternLine("White", 3, "W, L Frt Kick", "W, Chamber", "W, Palm-Chest"),
                new PatternLine("Gold", 1, "W, L Frt Stn", "W, High Blk", "W, Chamber"),
                new PatternLine("Gold", 2, "W, R Frt Stn", "W, Chamber", "W, Frt Punch"),
                new PatternLine("Gold", 3, "W, R Frt Stn", "W, Low Punch", "W, Chamber")
            };
            var lines = from line in patternLines where line.Rank.Equals(Rank) select line;
            RankLines = lines.ToList();
        }
        private async void OnRefreshCommand()
        {
            IsRefreshing = true;
            await Task.Delay(1000);
            IsRefreshing = false;
        }
        private void OnNewCommand() { }
        private void OnCancelCommand() { }
        private void OnEditCommand()
        {
            System.Diagnostics.Debug.WriteLine("\n\n\n" + SelectedItem.Feet + "\n\n\n");
            MessagingCenter.Send(this, "EditLine", SelectedItem);
        }
        private void OnDeleteCommand() { }

    }
}
