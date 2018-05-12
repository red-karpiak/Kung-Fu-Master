using Kung_Fu_Tracker.Classes;
using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.DetailViews.Patterns
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Patterns : ContentPage
    {
        List<string> ranks = new List<string>();
        public PatternsViewModel patternViewModel;
        public Patterns()
        {
            InitializeComponent();
            patternViewModel = new PatternsViewModel();
            this.BindingContext = patternViewModel;
        }
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<PatternsViewModel, string>(this, "Pattern", (sender, selectedItem) =>
            {
                string rank = selectedItem;
                Navigation.PushAsync(new PatternDetails(rank));
            });
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<PatternsViewModel, string>(this, "Pattern");
            base.OnDisappearing();
        }
    }
}