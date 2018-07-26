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
    /// <summary auth="J.Karpiak" date="26/07/18">
    /// this page contains a datagrid of all the entries in in the database for that specific line. As well as a the ability to add, edit
    /// and delete lines.
    /// </summary>
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
            //the "pageNavigated flag" is necessary to stop the multiple stacking of pages.
            pageNavigated = false;
            PatternDetailsViewModel.OnRefreshCommand();
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
            MessagingCenter.Subscribe<PatternDetailsViewModel, int>(this, "DeleteLine", (sender, ID) =>
            {
                ShowDeleteDialog(ID);
            });
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<PatternDetailsViewModel, string>(this, "NewLine");
            MessagingCenter.Unsubscribe<PatternDetailsViewModel, PatternLine>(this, "EditLine");
            MessagingCenter.Unsubscribe<PatternDetailsViewModel, PatternLine>(this, "DeleteLine");
            base.OnDisappearing();
        }
        private async void ShowDeleteDialog(int id)
        {
            var answer = await DisplayAlert("Delete", "Are you sure you want to delete this line?", "Yes", "No");
            if (answer)
            {
                await App.restService.DeletePatternLine(id);
                PatternDetailsViewModel.OnRefreshCommand();
            }
        }
    }
}