using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            SubscribeToMessagingCenterEvents();
            SubscribeToEntriesOnCompleted();
            base.OnAppearing();
        }
        

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<SettingsViewModel, bool>(this, "ToggleFrame");
            MessagingCenter.Unsubscribe<SettingsViewModel, bool>(this, "PasswordChangeError");
            MessagingCenter.Unsubscribe<SettingsViewModel, bool>(this, "ConfirmPasswordChange");
            MessagingCenter.Unsubscribe<SettingsViewModel, bool>(this, "ClearPasswordEntries");
            base.OnDisappearing();
        }
        
        private void SubscribeToEntriesOnCompleted()
        {
            changeOldPass.Completed += (object sender, EventArgs e) =>
            {
                changeNewPass1.Focus();
            };
            changeNewPass1.Completed += (object sender, EventArgs e) =>
            {
                changeNewPass2.Focus();
            };
        }
        private void SubscribeToMessagingCenterEvents()
        {
            //when the user confirms the password change
            MessagingCenter.Subscribe<SettingsViewModel, Dictionary<string, string>>(this, "ConfirmPasswordChange", (sender, dictPasswords) =>
            {
                dictPasswords["OldPass"] = changeOldPass.Text;
                dictPasswords["NewPass1"] = changeNewPass1.Text;
                dictPasswords["NewPass2"] = changeNewPass2.Text;
            });
            MessagingCenter.Subscribe<SettingsViewModel>(this, "ClearPasswordEntries", (sender) =>
            {
                changeOldPass.Text = changeNewPass1.Text = changeNewPass2.Text = "";
            });
            //when there is an error with the password change
            MessagingCenter.Subscribe<SettingsViewModel, string>(this, "PasswordChangeError", (sender, errorMessage) =>
            {
                DisplayAlert("Password Change Error", errorMessage, "Close");
            });
            MessagingCenter.Subscribe<SettingsViewModel, bool>(this, "ToggleFrame", (sender, passFrameVisible) =>
            {
                if (!passFrameVisible)
                {
                    alFrameLayout.IsVisible = false;
                    gridSettings.IsEnabled = true;
                    gridSettings.Opacity = 1;
                }
                else
                {
                    changeOldPass.Focus();
                    alFrameLayout.IsVisible = true;
                    gridSettings.IsEnabled = false;
                    gridSettings.Opacity = 0.25;
                }
            });
        }
    }
}