using Kung_Fu_Tracker.DataManagement;
using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserInfo : ContentPage
    {
        //NOTE: Research how to use a datepicker later, not needed yet.
        public string Username { get; set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public UserInfo()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            Title = "User Information";
            Username = App.LoggedInUser.Username;
            ScreenWidth = (int)App.DisplayScreenWidth;
            ScreenHeight = (int)App.DisplayScreenHeight;
            
            elActivitySpinner.IsVisible = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert(Username, ScreenWidth.ToString() + " : " + ScreenHeight.ToString(), "Cancel");
        }
    }
}