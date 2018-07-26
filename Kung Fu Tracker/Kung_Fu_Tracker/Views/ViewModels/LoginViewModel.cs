using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kung_Fu_Tracker.Views.Menu;
using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.DataManagement;

namespace Kung_Fu_Tracker.Views.ViewModels
{
    public class LoginViewModel
    {
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
                //if (App.SettingsDatabase.GetSettings() == null)
                //{
                //    Settings settings = new Settings();
                //    App.SettingsDatabase.SaveSettings(settings);
                //}
                ////var result = await App.RestService.Login(user);
                //var result = new Token(); //dummy token for testing purposes
                //// if (result.accessToken != null)
                //if (result != null)
                //{
                    //activitySpinner.IsVisible = false;
                    //App.UserDatabase.SaveUser(user);
                    //App.TokenDatabase.SaveToken(result);
                App.LoggedIn = true;

                App.restService = new RestService();
                if (Device.RuntimePlatform == Device.Android)
                {
                    Application.Current.MainPage = new MasterDetail();
                }
                //else if (Device.RuntimePlatform == Device.iOS)
                //{
                //    Application.Current.MainPage = new MasterDetail();
                //}
                
            }
        }
    }
}
