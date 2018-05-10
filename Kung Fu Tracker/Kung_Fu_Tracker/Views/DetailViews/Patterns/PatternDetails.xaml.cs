using Kung_Fu_Tracker.DataManagement;
using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.DetailViews.Patterns
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatternDetails : ContentPage
    {
        public PatternDetailsViewModel PatternDetailsViewModel { get; set; }
        public PatternDetails(string rank)
        {
            InitializeComponent();
            PatternDetailsViewModel = new PatternDetailsViewModel(rank);
            this.BindingContext = PatternDetailsViewModel;
        }
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<PatternDetailsViewModel, string>(this, "NewLine", (sender, rank) =>
            {
                //navigate to pattern line page
                PatternLine line = new PatternLine(rank);
                Navigation.PushAsync(new PatternLinePage(line));
            });
            MessagingCenter.Subscribe<PatternDetailsViewModel, PatternLine>(this, "EditLine", (sender, patternLine) =>
            {
                //navigate to pattern line page to edit
                Navigation.PushAsync(new PatternLinePage(patternLine));
            });
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<PatternDetailsViewModel, string>(this, "NewPattern");
            MessagingCenter.Unsubscribe<PatternDetailsViewModel, PatternLine>(this, "EditPattern");
            base.OnDisappearing();
        }
    }
}