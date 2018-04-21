using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.DetailViews;
using Kung_Fu_Tracker.Views.DetailViews.SettingsViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return lvContent; } }
        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }
        private void SetItems()
        {
            List<MasterMenuItem> menuList = new List<MasterMenuItem>();
            menuList.Add(new MasterMenuItem("User Information", "icon.png", Color.White, typeof(UserInfo)));
            menuList.Add(new MasterMenuItem("Patterns", "icon.png", Color.White, typeof(Patterns)));
            menuList.Add(new MasterMenuItem("Settings", "Settings.ico", Color.White, typeof(SettingsHome)));
            lvContent.ItemsSource = menuList;
        }
        private void btnLogout_ClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}