using Kung_Fu_Tracker.Views.ViewModels;
using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.DetailViews.Patterns
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PatternLinePage : ContentPage
	{
        public PatternLineViewModel PatternLineViewModel { get; set; }
        int count = 0;
        public PatternLinePage (PatternLine line)
		{
			InitializeComponent();
            PatternLineViewModel = new PatternLineViewModel(line);
            NavigationPage.SetHasBackButton(this, false);
            this.BindingContext = PatternLineViewModel;
		}
        protected override void OnAppearing()
        {

            count = Navigation.NavigationStack.Count();
            /* MessagingCenter.Subscribe<PatternDetailsViewModel, string>(this, "Save", (sender, rank) =>
             {
                 //save pattern
                 softwareBackButtonPressed = false;
                 Navigation.PopAsync();

             });
             MessagingCenter.Subscribe<PatternDetailsViewModel, PatternLine>(this, "Cancel", (sender, patternLine) =>
             {
             softwareBackButtonPressed = false;
                 Navigation.PopAsync();
                 //cancel pattern changes
             });*/
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            //  MessagingCenter.Unsubscribe<PatternDetailsViewModel, string>(this, "Save");
            // MessagingCenter.Unsubscribe<PatternDetailsViewModel, PatternLine>(this, "Cancel");
            
            base.OnDisappearing();
           // Navigation.RemovePage(this);
        }
    }
}