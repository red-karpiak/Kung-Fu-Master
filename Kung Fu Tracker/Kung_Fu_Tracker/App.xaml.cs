using Kung_Fu_Tracker.DataManagement;
using Kung_Fu_Tracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kung_Fu_Tracker
{
    public partial class App : Application
    {
        static PatternDBController patternDatabase;
        static UserDBController userDatabase;
        static TokenDBController tokenDatabase;
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
        public static TokenDBController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDBController();
                }
                return tokenDatabase;
            }
        }
        public static UserDBController UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDBController();
                }
                return userDatabase;
            }
        }
        public static PatternDBController PatternDatabase
        {
            get
            {
                if (patternDatabase == null)
                {
                    patternDatabase = new PatternDBController();
                }
                return patternDatabase;
            }
        }
    }
}
