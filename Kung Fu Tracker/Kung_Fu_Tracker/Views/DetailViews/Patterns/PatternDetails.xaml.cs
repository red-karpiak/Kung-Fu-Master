using Kung_Fu_Tracker.DataManagement;
using Kung_Fu_Tracker.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.DetailViews.Patterns
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatternDetails : ContentPage
    {
        public PatternDetailsViewModel PatternDetailsViewModel { get; set; }
        public PatternDetails(string rank)
        {
            InitializeComponent();
            PatternDetailsViewModel = new PatternDetailsViewModel(rank);
            this.BindingContext = PatternDetailsViewModel;
        }
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<PatternDetailsViewModel, string>(this, "NewPattern", (sender, rank) =>
            {

            });
            base.OnAppearing();
        }
    }
}