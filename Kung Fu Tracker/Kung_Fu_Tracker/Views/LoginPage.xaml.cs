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
        public LoginModel loginModel;
        public LoginPage()
        {
            InitializeComponent();
            loginModel = new LoginModel();
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
            MessagingCenter.Subscribe<LoginModel, string>(this, "LoginAlert", (sender, username) =>
            {
                DisplayAlert("Login Failure", "You must supply a username", "Cancel");
            });
            MessagingCenter.Subscribe<LoginModel, string>(this, "LoginAlert", (sender, username) =>
            {
                DisplayAlert("Login Failure", "You must supply a password", "Cancel");
            });
        }
    }
}