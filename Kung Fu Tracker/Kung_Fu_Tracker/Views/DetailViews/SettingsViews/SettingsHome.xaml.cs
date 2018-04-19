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
        SwitchCell switchCell1;
        SwitchCell switchCell2;

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
            switchCell1 = new SwitchCell
            {
                Text = "Switch 1",
                On = settings.switch1
            };

            switchCell1.OnChanged += (object sender, ToggledEventArgs e) =>
            {
                SwitchCell1Changed(sender, e);
            };
            switchCell2 = new SwitchCell
            {
                Text = "Switch 2",
                On = settings.switch2
            };
            switchCell2.OnChanged += (object sender, ToggledEventArgs e) =>
            {
                SwitchCell2Changed(sender, e);
            };
            TableView table;

            table = new TableView
            {
                Root = new TableRoot
                {
                    new TableSection
                    {
                        switchCell1,
                        switchCell2
                    }
                }
            };

            table.VerticalOptions = LayoutOptions.FillAndExpand;
            MainLayout.Children.Add(table);

        }

        private void SwitchCell2Changed(object sender, ToggledEventArgs e)
        {
            settings.switch2 = e.Value;
        }

        private void SwitchCell1Changed(object sender, ToggledEventArgs e)
        {
            settings.switch1 = e.Value;
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            var action = await DisplayAlert("Settings", "Do you want to save these changes?", "OK", "Cancel");
            if (action)
                SaveSettings();
        }

        private void SaveSettings()
        {
            App.SettingsDatabase.SaveSettings(settings);
        }
    }
}