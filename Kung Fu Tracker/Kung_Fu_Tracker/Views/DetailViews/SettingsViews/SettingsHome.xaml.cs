using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.DetailViews.SettingsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsHome : ContentPage
    {
        public SettingsViewModel settingsViewModel;
        public SettingsHome()
        {
            InitializeComponent();
            settingsViewModel = new SettingsViewModel();
            this.BindingContext = settingsViewModel;
        }
        protected override void OnAppearing()
        {
            //when the user confirms the password change
            MessagingCenter.Subscribe<SettingsViewModel, List<string>>(this, "ConfirmPasswordChange", (sender, listOfPasswords) =>
            {
                listOfPasswords.Add(changeOldPass.Text);
                listOfPasswords.Add(changeNewPass1.Text);
                listOfPasswords.Add(changeNewPass2.Text);
            });

            //when there is an error with the password change
            MessagingCenter.Subscribe<SettingsViewModel, string>(this, "PasswordChangeError", (sender, errorMessage) =>
            {

            });

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}