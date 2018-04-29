using Kung_Fu_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Views.ViewModels
{
    public class SettingsViewModel
    {
        #region Variables and Properties
        Settings Settings { get; set; }
        public string UserPassword { get; set; }
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
        private bool passwordToggleView;
        public Thickness Thickness { get; set; }
        public bool PasswordToggleView
        {
            get => passwordToggleView;
            set => ToggleFrame(ref passwordToggleView, value);
            
        }
        public Dictionary<string, string> ChangePasswordValues { get; set; }
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
                ChangePasswordValues = new Dictionary<string, string>();
            }

            PasswordToggleView = false;

            //AbsYTranslation = (int)(App.DisplayScreenHeight / 4);
            Thickness = new Thickness(0, (int)(App.DisplayScreenHeight / 5), 0, 0);

            //all commands to subscribe to
            PasswordChangeCommand = new Command(OnPasswordChange);
            CheckConnectionCommand = new Command(OnCheckConnection);
            ConfirmPasswordChange = new Command(OnConfirmPasswordChange);
            CancelPasswordChange = new Command(OnCancelPasswordChange);

            UserPassword = App.LoggedInUser.Password;
            
        }
        public void OnPasswordChange()
        {
            PasswordToggleView = true;
        }
        public void OnCheckConnection()
        {
            MessagingCenter.Send(this, "CheckConnection");
        }
        public void OnConfirmPasswordChange()
        {
            PasswordToggleView = false;
            MessagingCenter.Send(this, "ConfirmPasswordChange", ChangePasswordValues);
            MessagingCenter.Send(this, "ClearPasswordEntries");
            if (!ChangePasswordValues["OldPass"].Equals(UserPassword))
            {
                MessagingCenter.Send(this, "PasswordChangeError", "Incorrect Password");
                return;
            }
            if (!ChangePasswordValues["NewPass1"].Equals(ChangePasswordValues["NewPass2"]))
            {
                MessagingCenter.Send(this, "PasswordChangeError", "New Passwords Must Match");
                return;
            }
            App.LoggedInUser.Password = UserPassword = ChangePasswordValues["NewPass1"];
        }
        public void OnCancelPasswordChange()
        {
            PasswordToggleView = false;
            MessagingCenter.Send(this, "ClearPasswordEntries");
        }
        private void ToggleFrame(ref bool property, bool value)
        {
            if (property != value)
                property = value;
            MessagingCenter.Send(this, "ToggleFrame", passwordToggleView);
        }
    }
}
