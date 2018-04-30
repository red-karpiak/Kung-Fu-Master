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
        public NewPatternViewModel NewPatternViewModel { get; set; }
        public NewPatternPage ()
		{
			InitializeComponent();
            NewPatternViewModel = new NewPatternViewModel();
            this.BindingContext = NewPatternViewModel;
		}
	}
}