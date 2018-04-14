using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.Menu;

namespace Kung_Fu_Tracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            lblBanner.Text = "少林功夫";
            lblBanner.TextColor = Constants.MainTextColor;
            lblBanner.FontSize = 80;
            BackgroundColor = Constants.BackgroundColor;
            lblUsername.TextColor = Constants.MainTextColor;
            lblPassword.TextColor = Constants.MainTextColor;
            entUsername.BackgroundColor = Constants.EntryColor;
            entPassword.BackgroundColor = Constants.EntryColor;
            App.StartCheckIfInternet(lblNoInternet, this);
            activitySpinner.IsVisible = false;

            entUsername.Completed += (s, e) => entPassword.Focus();
            entPassword.Completed += async (s, e) => await butSignIn_ClickedAsync(s, e);

        }
        async Task butSignIn_ClickedAsync(object sender, EventArgs e)
        {
            User user = new User(entUsername.Text, entPassword.Text);
            if (user.CheckInformation())
            {
                await DisplayAlert("Login", "Login Successful", "OK");
                //var result = await App.RestService.Login(user);
                var result = new Token(); //dummy token for testing purposes
               // if (result.accessToken != null)
                if (result != null)
                {
                    //App.UserDatabase.SaveUser(user);
                    //App.TokenDatabase.SaveToken(result);
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        Application.Current.MainPage = new NavigationPage(new Dashboard());
                    }
                    else if (Device.RuntimePlatform == Device.iOS)
                    { 
                        await Navigation.PushAsync(new NavigationPage(new Dashboard()));
                    }
                }
            }
            else
            {
                await DisplayAlert("Login", "Login Failed", "OK");
            }
        }
    }
}