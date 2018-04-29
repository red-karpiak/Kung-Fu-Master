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
        Settings Settings { get; set; }
        public string UserPassword { get; }
        private bool switchOneOn;
        public bool SwitchOneOn {
            get { return switchOneOn; }
            set
            {
                if (switchOneOn != value)
                {
                    switchOneOn = value;
                    Settings.Switch1 = switchOneOn;
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
                    Settings.Switch2 = switchTwoOn;
                }
            }
        }
        public ICommand PasswordChangeCommand { get; set; }
        public ICommand CheckConnectionCommand { get; set; }
        public ICommand ConfirmPasswordChange { get; set; }
        public ICommand CancelPasswordChange { get; set; }
        public bool IsChangePasswordFrameVisible { get; set; }
        public bool IsSettingsPageEnabled { get; set; }
        public List<string> ChangePasswordValues { get; set; }
        #endregion

        //use this property to change move the "dialog" up the page.
        public int AbsYTranslation { get; set; }
        public SettingsViewModel()
        {
            if (Settings == null)
            {
                Settings = new Settings();
            }
            if (ChangePasswordValues == null)
            {
                ChangePasswordValues = new List<string>();
            }

            IsChangePasswordFrameVisible = false;
            IsSettingsPageEnabled = true;

            AbsYTranslation = -((int)App.DisplayScreenHeight / 4);

            //all commands to subscribe to
            PasswordChangeCommand = new Command(OnPasswordChange);
            CheckConnectionCommand = new Command(OnCheckConnection);
            ConfirmPasswordChange = new Command(OnConfirmPasswordChange);
            CancelPasswordChange = new Command(OnCancelPasswordChange);

            UserPassword = App.LoggedInUser.Password;
            
        }
        public void OnPasswordChange()
        {
            IsSettingsPageEnabled = false;
            IsChangePasswordFrameVisible = true;
        }
        public void OnCheckConnection()
        {
            MessagingCenter.Send(this, "CheckConnection");
        }
        public void OnConfirmPasswordChange()
        {
            MessagingCenter.Send(this, "ConfirmPasswordChange", ChangePasswordValues);
            IsSettingsPageEnabled = true;
            IsChangePasswordFrameVisible = false;
        }
        public void OnCancelPasswordChange()
        {
            IsSettingsPageEnabled = true;
            IsChangePasswordFrameVisible = false;
            MessagingCenter.Send(this, "CancelPasswordChange");
        }
    }
}
