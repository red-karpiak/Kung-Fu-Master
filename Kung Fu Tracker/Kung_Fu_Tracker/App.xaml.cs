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
        static PatternDatabaseController patternDatabase;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new Kung_Fu_Tracker.Pages.HomePage());
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
        public static PatternDatabaseController PatternDatabase
        {
            get
            {
                if (patternDatabase == null)
                {
                    patternDatabase = new PatternDatabaseController(DependencyService.Get<ISQLite>().GetLocalFilePath("PatternSQLite.db3"));
                }
                return patternDatabase;
            }
        }
    }
}
