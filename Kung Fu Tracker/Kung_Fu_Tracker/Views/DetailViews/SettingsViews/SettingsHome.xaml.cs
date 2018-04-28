using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.ViewModels;
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
        public SettingsViewModel settingsViewModel;
        public SettingsHome()
        {
            InitializeComponent();
            settingsViewModel = new SettingsViewModel();
            this.BindingContext = settingsViewModel;
        }
        protected override void OnAppearing()
        {
            //App.StartCheckIfInternet(lblNoInternet, this);

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}