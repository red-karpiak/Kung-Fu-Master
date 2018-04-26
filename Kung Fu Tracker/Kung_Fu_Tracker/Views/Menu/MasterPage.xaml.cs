using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.DetailViews;
using Kung_Fu_Tracker.Views.DetailViews.SettingsViews;
using Kung_Fu_Tracker.Views.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return lvContent; } }
        public List<MasterMenuItem> Items { get; set; }
        public MasterPageModel masterPageModel;
        public MasterPage()
        {
            InitializeComponent();
            masterPageModel = new MasterPageModel();
            this.BindingContext = masterPageModel;
            SetItems();
        }
        private void SetItems()
        {
            Items = new List<MasterMenuItem>
            {
                new MasterMenuItem("User Information", "icon.png", Color.White, typeof(UserInfo)),
                new MasterMenuItem("Patterns", "icon.png", Color.White, typeof(Patterns)),
                new MasterMenuItem("Settings", "Settings.ico", Color.White, typeof(SettingsHome))
            };
        }
        private void btnLogout_ClickedAsync(object sender, EventArgs e)
        {
            App.LoggedIn = false;
            App.Current.MainPage = new LoginPage();
        }
    }
}