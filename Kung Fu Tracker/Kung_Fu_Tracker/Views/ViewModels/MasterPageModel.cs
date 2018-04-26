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
    public class MasterPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public ICommand LogoutCommand { get; set; }
        
        public MasterPageModel()
        { 
            LogoutCommand = new Command(OnLogout);
        }
        public void OnLogout()
        {
            App.LoggedIn = false;
            App.Current.MainPage = new LoginPage();
        }
    }
}
