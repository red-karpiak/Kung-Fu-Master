using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Views.ViewModels
{
    public class UserInfoViewModel
    {
        public ICommand ButtonCommand { get; set; }
        public bool IsActivityIndicatorRunning { get; set; }
        public bool IsActivityIndicatorVisible { get; set; }
        public bool IsActivityIndicatorEnabled { get; set; }
        public string Username { get; set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }

        public UserInfoViewModel()
        {
            Init();
            ButtonCommand = new Command(OnButtonPress);
        }
        public void OnButtonPress()
        {
            List<string> list = new List<string>
            {
                Username,
                ScreenHeight.ToString(),
                ScreenWidth.ToString()
            };
            MessagingCenter.Send(this, "UserInfo", list);
        }
        private void Init()
        {
            Username = App.LoggedInUser.Username;
            ScreenWidth = (int)App.DisplayScreenWidth;
            ScreenHeight = (int)App.DisplayScreenHeight;
            IsActivityIndicatorVisible = false;
        }
    }
}
