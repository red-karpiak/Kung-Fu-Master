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
        private bool pageNavigated = false;
        public PatternDetails(string rank)
        {
            InitializeComponent();
            PatternDetailsViewModel = new PatternDetailsViewModel(rank);
            this.BindingContext = PatternDetailsViewModel;
        }
        protected override void OnAppearing()
        {

            pageNavigated = false;
            MessagingCenter.Subscribe<PatternDetailsViewModel, string>(this, "NewLine", (sender, rank) =>
            {
                //navigate to pattern line page
                PatternLine line = new PatternLine(rank);
                if (!pageNavigated)
                    Navigation.PushAsync(new PatternLinePage(line));
                pageNavigated = true;
            });
            MessagingCenter.Subscribe<PatternDetailsViewModel, PatternLine>(this, "EditLine", (sender, patternLine) =>
            {
                //navigate to pattern line page to edit
                if (!pageNavigated)
                    Navigation.PushAsync(new PatternLinePage(patternLine));
                pageNavigated = true;
            });
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<PatternDetailsViewModel, string>(this, "NewLine");
            MessagingCenter.Unsubscribe<PatternDetailsViewModel, PatternLine>(this, "EditLine");
            base.OnDisappearing();
        }
    }
}