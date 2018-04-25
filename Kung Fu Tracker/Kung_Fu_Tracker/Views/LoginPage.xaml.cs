﻿using System;
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
        public LoginModel loginModel;
        public LoginPage()
        {
            InitializeComponent();
            loginModel = new LoginModel();
            MessagingCenter.Subscribe<LoginModel,string>(this, "LoginAlert", (sender,username) =>
            {
                DisplayAlert("Login Failure", "You must supply a password", "Cancel");
            });
            this.BindingContext = loginModel;
            entUsername.Completed += (object sender, EventArgs e) =>
            {
                entPassword.Focus();
            };
            entPassword.Completed += (object sender, EventArgs e) =>
            {
                loginModel.SubmitCommand.Execute(null);
            };
            //Init();
        }
        public void Subscriptions()
        {

        }
        //void Init()
        //{
        //    lblBanner.Text = "少林功夫";
        //    lblBanner.TextColor = Constants.MainTextColor;
        //    lblBanner.FontSize = 40;
        //    BackgroundColor = Constants.BackgroundColor;
        //    lblUsername.TextColor = Constants.MainTextColor;
        //    lblPassword.TextColor = Constants.MainTextColor;
        //    entUsername.BackgroundColor = Constants.EntryColor;
        //    entPassword.BackgroundColor = Constants.EntryColor;
        //    App.StartCheckIfInternet(lblNoInternet, this);
        //    activitySpinner.IsVisible = false;

        //    entUsername.Completed += (s, e) => entPassword.Focus();
        //    entPassword.Completed += async (s, e) => await butSignIn_ClickedAsync(s, e);

        //}
        //async Task ButSignIn_ClickedAsync(object sender, EventArgs e)
        //{
        //    //static user temporary for UI testing, move to database entries later.
        //    App.LoggedInUser = new User(entUsername.Text, entPassword.Text);
            
        //    if (App.LoggedInUser.CheckInformation())
        //    {
        //        activitySpinner.IsVisible = true;
                
        //        //await DisplayAlert("Login", "Login Successful", "OK");

        //        if (App.SettingsDatabase.GetSettings() == null)
        //        {
        //            Settings settings = new Settings();
        //            App.SettingsDatabase.SaveSettings(settings);
        //        }
        //        //var result = await App.RestService.Login(user);
        //        var result = new Token(); //dummy token for testing purposes
        //       // if (result.accessToken != null)
        //        if (result != null)
        //        {
        //            //activitySpinner.IsVisible = false;
        //            //App.UserDatabase.SaveUser(user);
        //            //App.TokenDatabase.SaveToken(result);
        //            App.LoggedIn = true;
        //            if (Device.RuntimePlatform == Device.Android)
        //            {
        //                Application.Current.MainPage = new MasterDetail();
        //            }
        //            else if (Device.RuntimePlatform == Device.iOS)
        //            { 
        //                await Navigation.PushAsync(new MasterDetail());
        //            }
        //        }
        //    }
        //    else
        //    {
        //        App.LoggedIn = false;
        //        activitySpinner.IsVisible = false;
        //        await DisplayAlert("Login", "Login Failed", "OK");
        //    }
        //}
    }
}