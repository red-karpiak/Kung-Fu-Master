using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kung_Fu_Tracker.Models;

namespace Kung_Fu_Tracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void butSignIn_Clicked(object sender, EventArgs e)
        {
            User user = new User(entUsername.Text, entPassword.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login Successful", "OK");
            }
            else
            {
                DisplayAlert("Login", "Login Failed", "OK");
            }
        }
    }
}