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
    /// <summary auth="J.Karpiak" date="26/07/18">
    /// this page shows the detail of an individual line. The fields will be empty if it is a new line.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PatternLinePage : ContentPage
	{
        public PatternLineViewModel PatternLineViewModel { get; set; }
        public PatternLinePage (PatternLine line)
		{
			InitializeComponent();
            PatternLineViewModel = new PatternLineViewModel(line);
            this.BindingContext = PatternLineViewModel;
		}
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<PatternLineViewModel>(this, "Close", (sender) =>
            {
                Navigation.PopAsync();
            });
            MessagingCenter.Subscribe<PatternLineViewModel, string>(this, "Error", (sender, message) =>
            {
                ErrorMessage(message);
            });
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<PatternLineViewModel, string>(this, "Save");
            MessagingCenter.Unsubscribe<PatternLineViewModel, PatternLine>(this, "Cancel");
            MessagingCenter.Unsubscribe<PatternLineViewModel, string>(this, "Error");
            base.OnDisappearing();
        }
        private async void ErrorMessage(string message)
        {
            await DisplayAlert("Error", message, "Cancel");
        }
    }
}