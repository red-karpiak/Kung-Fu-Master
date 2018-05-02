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
	public partial class NewPatternPage : ContentPage
	{
        public PatternLineViewModel PatternLineViewModel { get; set; }
        public NewPatternPage (string Rank)
		{
			InitializeComponent();
            PatternLineViewModel = new PatternLineViewModel(Rank);
            this.BindingContext = PatternLineViewModel;
		}
	}
}