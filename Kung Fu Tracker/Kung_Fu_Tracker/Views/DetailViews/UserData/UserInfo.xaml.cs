using Kung_Fu_Tracker.Views.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.DetailViews.UserData
{
    /// <summary auth="J.Karpiak" date="26/07/18">
    /// just the opening page. just displays the user name. I want to add more details in the future. For Example:
    /// progress data, alerts, goals, etc.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserInfo : ContentPage
    {
        public UserInfoViewModel viewModel;
        public UserInfo()
        {
            InitializeComponent();
            viewModel = new UserInfoViewModel();
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<UserInfoViewModel, List<string>>(this, "UserInfo", (sender, list) =>
            {
                string message = "";
                foreach (string s in list)
                {
                    message += s + "\n";
                }
                DisplayAlert("Details", message, "Cancel");
            });
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<UserInfoViewModel, List<string>>(this, "UserInfo");
            base.OnDisappearing();
        }
    }
}