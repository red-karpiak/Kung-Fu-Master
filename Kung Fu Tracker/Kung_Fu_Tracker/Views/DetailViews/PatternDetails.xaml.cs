using Kung_Fu_Tracker.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Kung_Fu_Tracker.Views;
using Xamarin.Forms.DataGrid;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatternDetails : ContentPage
    {
        public DataGrid dataGrid;
        public List<Pattern> patterns;
        bool isRefreshing;
        public Pattern selectedItem;
        public PatternDetails(string rank)
        {
            //DataGridComponent.Init();
            InitializeComponent();
            Title = rank;
            InitGrid(rank);
        }
        public void InitGrid(string rank)
        {
            //TODO: pull the pattern steps from the db
            patterns = new List<Pattern>();
            patterns.Add(new Pattern(1, "White", "L: front stance", "L: low block\nR: chamber"));
            patterns.Add(new Pattern(2, "White", "R: front stance", "L: chamber\nR: Front punch"));
            patterns.Add(new Pattern(3, "White", "L: front kick", "L: chamber\nR: Palm to chest"));
            patterns.Add(new Pattern(4, "White", "R: front stance", "L: chamber\nR: low block"));
            patterns.Add(new Pattern(5, "White", "step back to R: cat stance", "L: chamber\nR: fist to L shoulder"));

        }

        public Pattern SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; OnPropertyChanged(nameof(IsRefreshing)); }
        }
    }
}