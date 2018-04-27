using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.Menu;
using Kung_Fu_Tracker.Views.ViewModels;

namespace Kung_Fu_Tracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel loginModel;
        public LoginPage()
        {
            InitializeComponent();
            loginModel = new LoginViewModel();
            Subscriptions();
            this.BindingContext = loginModel;
            entUsername.Completed += (object sender, EventArgs e) =>
            {
                entPassword.Focus();
            };
            entPassword.Completed += (object sender, EventArgs e) =>
            {
                loginModel.SubmitCommand.Execute(null);
            };
        }
        public void Subscriptions()
        {
            MessagingCenter.Subscribe<LoginViewModel, string>(this, "InvalidUsername", (sender, username) =>
            {
                DisplayAlert("Login Failure", "You must supply a username", "Cancel");
            });
            MessagingCenter.Subscribe<LoginViewModel, string>(this, "InvalidPassword", (sender, password) =>
            {
                DisplayAlert("Login Failure", "You must supply a password", "Cancel");
            });
        }
    }
}