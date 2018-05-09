using Kung_Fu_Tracker.DataManagement;
using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.DetailViews;
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
        public List<PatternLine> patternLines;
        public List<PatternLine> PatternLines
        {
            get { return patternLines; }
            set
            {
                patternLines = value;
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
        string data { get; set; }
        
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
        private async void InitGrid(string rank)
        {
            data = await App.restService.GetData();
            //PatternLines = await App.restService.GetData();
            //Patterns = new ObservableCollection<Pattern>
            //{
            //    new Pattern("White", 1, "L: front stance", "L: low block\nR: chamber"),
            //    new Pattern("White", 2, "R: front stance", "L: chamber\nR: Front punch"),
            //    new Pattern("White", 3, "L: front kick", "L: chamber\nR: Palm to chest"),
            //    new Pattern("White", 4, "R: front stance", "L: chamber\nR: low block"),
            //    new Pattern("White", 5, "step back to R: cat stance", "L: chamber\nR: fist to L shoulder")
            //};
        }
        private async void OnRefreshCommand()
        {
            IsRefreshing = true;
            await Task.Delay(1000);
            IsRefreshing = false;
        }
        private void OnNewCommand()
        {

        }
        private void OnCancelCommand() { }
        private void OnEditCommand()
        {

        }
        private void OnDeleteCommand()
        {

        }

    }
}
