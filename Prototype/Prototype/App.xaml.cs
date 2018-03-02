using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace Prototype
{
    public partial class App : Application
    {

        public App()
        {
            // The root page of your application
            MainPage = new AppNavigationPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("ios={aa5a52f6-a4a7-4a21-a385-a7b954dc702c};android={fc49221a-62ef-414d-b574-52a18916f637}", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
