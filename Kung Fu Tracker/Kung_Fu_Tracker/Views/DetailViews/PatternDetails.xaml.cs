using Kung_Fu_Tracker.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatternDetails : ContentPage
    {
        public List<Pattern> Patterns { get; set; }
        bool isRefreshing = false;
        public Pattern SelectedItem { get; set; }
        public PatternDetails(string rank)
        {
            //DataGridComponent.Init();
            InitializeComponent();
            Title = rank;
            InitGrid(rank);
            RefreshCommand = new Command(CmdRefresh);
        }
        public void InitGrid(string rank)
        {
            //TODO: pull the pattern steps from the db. Hardcoding for testing purposes.
            Patterns = new List<Pattern>
            {
                new Pattern("White", 1, "L: front stance", "L: low block\nR: chamber"),
                new Pattern("White", 2, "R: front stance", "L: chamber\nR: Front punch"),
                new Pattern("White", 3, "L: front kick", "L: chamber\nR: Palm to chest"),
                new Pattern("White", 4, "R: front stance", "L: chamber\nR: low block"),
                new Pattern("White", 5, "step back to R: cat stance", "L: chamber\nR: fist to L shoulder")
            };
        }
        public ICommand RefreshCommand { get; set; }

        private async void CmdRefresh()
        {
            IsRefreshing = true;
            // wait 3 secs for demo
            await Task.Delay(1000);
            IsRefreshing = false;
        }
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; OnPropertyChanged(nameof(IsRefreshing)); }
        }
    }
}