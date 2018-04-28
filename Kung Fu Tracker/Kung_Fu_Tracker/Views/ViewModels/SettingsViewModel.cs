using Kung_Fu_Tracker.Models;
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
    public class SettingsViewModel : INotifyPropertyChanged
    {
        #region Variables and Properties
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
        public ICommand PasswordChangeCommand { get; set; }
        public ICommand CheckConnectionCommand { get; set; }
        public ICommand ConfirmPasswordChange { get; set; }
        public ICommand CancelPasswordChange { get; set; }
        public bool IsChangePasswordFrameVisible { get; set; }
        public bool IsSettingsPageEnabled { get; set; }
        #endregion

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

            IsChangePasswordFrameVisible = false;
            IsSettingsPageEnabled = true;

            //all commands to subscribe to
            PasswordChangeCommand = new Command(OnPasswordChange);
            CheckConnectionCommand = new Command(OnCheckConnection);
            ConfirmPasswordChange = new Command(OnConfirmPasswordChange);
            CancelPasswordChange = new Command(OnCancelPasswordChange);

            UserPassword = App.LoggedInUser.Password;
            
        }
        public void OnPasswordChange()
        {
            MessagingCenter.Send(this, "PasswordChange", UserPassword);
        }
        public void OnCheckConnection()
        {
            MessagingCenter.Send(this, "CheckConnection");
        }
        public void OnConfirmPasswordChange()
        {
            MessagingCenter.Send(this, "ConfirmPasswordChange");
        }
        public void OnCancelPasswordChange()
        {
            MessagingCenter.Send(this, "CancelPasswordChange");
        }
    }
}
