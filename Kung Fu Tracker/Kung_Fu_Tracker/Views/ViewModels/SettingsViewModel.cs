using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kung_Fu_Tracker.Views.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        Settings settings { get; set; }
        public string UserPassword { get; }
        private bool switchOneOn;
        public bool SwitchOneOn {
            get { return switchOneOn; }
            set
            {
                if (switchOneOn != value)
                {
                    switchOneOn = value;
                    settings.Switch1 = switchOneOn;
                }
            }
        }
        private bool switchTwoOn;
        public bool SwitchTwoOn
        {
            get { return switchTwoOn; }
            set
            {
                if (switchTwoOn != value)
                {
                    switchTwoOn = value;
                    settings.Switch2 = switchTwoOn;
                }
            }
        }
        public ICommand PasswordChangeCommand;
        //use this property to change move the "dialog" up the page.
        public int AbsYTranslation
        {
            get
            {
                return -((int)App.DisplayScreenHeight / 4);
            }
        }
        public SettingsViewModel()
        {
            if (settings == null)
            {
                settings = new Settings();
            }
            UserPassword = App.LoggedInUser.Password;
            
        }
        public void OnPasswordChange()
        {

        }
    }
}
