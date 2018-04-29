using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using Xamarin.Forms;
using Kung_Fu_Tracker.Views.Menu;
using Kung_Fu_Tracker.Models;

namespace Kung_Fu_Tracker.Views.ViewModels
{
    public class LoginViewModel
    {
        private string username;

        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand SubmitCommand { get; set; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            if (string.IsNullOrEmpty(Username))
            {
                //because the functionality of the ContentPage class is not available in the ViewModel, we have to use
                //a MessagingCenter, a utility that handles messages between classes
                MessagingCenter.Send(this, "InvalidUsername", Username);
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                MessagingCenter.Send(this, "InvalidPassword", Password);
                return;
            }
            App.LoggedInUser = new User(Username, Password);

            if (App.LoggedInUser.CheckInformation())
            {
                if (App.SettingsDatabase.GetSettings() == null)
                {
                    Settings settings = new Settings();
                    App.SettingsDatabase.SaveSettings(settings);
                }
                //var result = await App.RestService.Login(user);
                var result = new Token(); //dummy token for testing purposes
                // if (result.accessToken != null)
                if (result != null)
                {
                    //activitySpinner.IsVisible = false;
                    //App.UserDatabase.SaveUser(user);
                    //App.TokenDatabase.SaveToken(result);
                    App.LoggedIn = true;
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        Application.Current.MainPage = new MasterDetail();
                    }
                }
            }
        }
    }
}
