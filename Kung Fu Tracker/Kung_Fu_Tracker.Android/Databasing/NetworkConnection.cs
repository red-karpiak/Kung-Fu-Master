using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Kung_Fu_Tracker.Droid.Databasing;
using Kung_Fu_Tracker.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]
namespace Kung_Fu_Tracker.Droid.Databasing
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected { get; set; }

        public void CheckNetworkConnection()
        {
            var connManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var activeNetworkInfo = connManager.ActiveNetworkInfo;
            if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = false;
            }
        }
    }
}