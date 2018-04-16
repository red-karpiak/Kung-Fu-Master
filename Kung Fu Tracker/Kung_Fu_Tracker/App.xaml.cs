using Kung_Fu_Tracker.DataManagement;
using Kung_Fu_Tracker.Interfaces;
using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kung_Fu_Tracker
{
    public partial class App : Application
    {
        static RestService restService;
        static PatternDBController patternDatabase;
        static UserDBController userDatabase;
        static TokenDBController tokenDatabase;
        static SettingsDBController settingsDatabase;
        private static Label labelScreen;
        private static bool hasInternet;
        private static Page currentPage;
        private static Timer timer;
        private static bool noInterShow;

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

        #region Connection and database properties
        public static RestService RestService
        {
            get
            {
                if (restService == null)
                {
                    restService = new RestService();
                }
                return restService;
            }
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
        public static SettingsDBController SettingsDatabase
        {
            get
            {
                if (settingsDatabase == null)
                {
                    settingsDatabase = new SettingsDBController();
                }
                return settingsDatabase;
            }
        }
        #endregion

        #region Connection functions
        public static void StartCheckIfInternet(Label label, Page page)
        {
            labelScreen = label;
            labelScreen.Text = Constants.noInternetText;
            labelScreen.IsVisible = false;
            hasInternet = true;
            currentPage = page;
            if (timer == null)
            {
                timer = new Timer((e) =>
                {
                    CheckIfInternetOvertime();
                }, null, 10, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
        }
        private static void CheckIfInternetOvertime()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                //because the timer is in a different thread, we have to call BeginInvokeOnMainThread, 
                //otherwise the ui elements won't change
                Device.BeginInvokeOnMainThread(async() =>
                {
                    if (hasInternet)
                    {
                        if (!noInterShow)
                        {
                            hasInternet = false;
                            labelScreen.IsVisible = true;
                            await ShowDisplayAlert();
                        }
                    }
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    hasInternet = true;
                    labelScreen.IsVisible = false;
                });
            }
        }

        public static async Task<bool> CheckConnection()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            return networkConnection.IsConnected;
        }

        public static async Task<bool> CheckIfInternetAlert()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                if (!noInterShow)
                {
                    await ShowDisplayAlert();
                }
                return false;
            }
            return true;
        }

        private static async Task ShowDisplayAlert()
        {
            noInterShow = false;
            await currentPage.DisplayAlert("Internet", "Device has no Internet. Please reconnect.", "OK");
            noInterShow = false;
        }
        #endregion
    }
}
