using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kung_Fu_Tracker.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetailModel masterDetailModel;
        public MasterDetail()
        {
            InitializeComponent();
            //we may decide to use this model later, but for now just leave it commented.
            //this.BindingContext = masterDetailModel;
        }
    }
}