using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public SettingsViewModel()
        {
            UserPassword = App.LoggedInUser.Password;
        }
    }
}
