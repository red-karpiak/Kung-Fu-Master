using Kung_Fu_Tracker.Views.ViewModels;
using Kung_Fu_Tracker.Models;
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
	public partial class PatternLinePage : ContentPage
	{
        public PatternLineViewModel PatternLineViewModel { get; set; }
        public PatternLinePage (PatternLine line)
		{
			InitializeComponent();
            PatternLineViewModel = new PatternLineViewModel(line);
            this.BindingContext = PatternLineViewModel;
		}
	}
}