﻿using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.DetailViews.Patterns;
using Kung_Fu_Tracker.Views.DetailViews.SettingsViews;
using Kung_Fu_Tracker.Views.DetailViews.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Views.ViewModels
{
    /// <summary>
    /// Logic and functionality for the master page
    /// </summary>
    public class MasterPageViewModel
    {
        public List<MasterMenuItem> Items { get; set; }
        public ICommand LogoutCommand { get; set; }

        private MasterMenuItem selectedItem;
        public MasterMenuItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    MessagingCenter.Send(this, "MasterDetail", selectedItem);
                }
            }
        }
        public MasterPageViewModel()
        {
            LogoutCommand = new Command(OnLogout);
            SetItems();
        }
        public void OnLogout()
        {
            App.LoggedIn = false;
            App.Current.MainPage = new LoginPage();
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
    }
}
