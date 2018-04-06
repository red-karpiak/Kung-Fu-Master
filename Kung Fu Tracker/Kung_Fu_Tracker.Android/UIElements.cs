using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Kung_Fu_Tracker.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Kung_Fu_Tracker.Droid.UIElements))]
namespace Kung_Fu_Tracker.Droid
{
    class UIElements : IUIElements
    {
        public void toast(List<string> messages)
        {
            string message = "";
            foreach (string s in messages)
            {
                message += s + ", ";
            }
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}