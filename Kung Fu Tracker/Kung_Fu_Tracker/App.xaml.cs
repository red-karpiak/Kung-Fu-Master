using Kung_Fu_Tracker.DataManagement;
using Kung_Fu_Tracker.Interfaces;
using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kung_Fu_Tracker
{
    public partial class App : Application
    {
        public static bool LoggedIn = false;
        public static RestService restService;

        public static double DisplayScreenWidth;
        public static double DisplayScreenHeight;
        public static double DisplayScaleFactor;

        public static User LoggedInUser { get; set; } //temporary until database is functional, just for UI testing

        public App()
        {
            InitializeComponent();
            MainPage = new Views.LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        
    }
}
