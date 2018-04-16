using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.DetailViews.SettingsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsHome : ContentPage
    {
        Settings settings { get; set; }
        User user { get; set; }
        public SettingsHome()
        {
            InitializeComponent();
            this.BackgroundColor = Constants.BackgroundColor;
            LoadSettings();
            
            Title = Constants.settingsTitleText;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.StartCheckIfInternet(lblNoInternet, this);
        }
        private void LoadSettings()
        {
            settings = App.SettingsDatabase.GetSettings();
            //currentUser = App.UserDatabase.GetUser();

        }
    }
}