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
    /// <summary>
    /// The master page hold all the functionality of navigation to different pages up selection
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public MasterPageViewModel masterPageModel;
        public MasterPage()
        {
            InitializeComponent();
            masterPageModel = new MasterPageViewModel();
            this.BindingContext = masterPageModel;
        }
        protected override void OnAppearing()
        {
            //navigate to the selected page
            MessagingCenter.Subscribe<MasterPageViewModel, MasterMenuItem>(this, "MasterDetail", (sender, selectedItem) =>
            {
                var item = selectedItem as MasterMenuItem;
                ((MasterDetailPage)Application.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                ((MasterDetailPage)Application.Current.MainPage).IsPresented = false;
            });
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<MasterPageViewModel, MasterMenuItem>(this, "MasterDetail");
            base.OnDisappearing();
        }

    }
}