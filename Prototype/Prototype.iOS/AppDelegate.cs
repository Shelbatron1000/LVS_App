using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Prototype.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public bool LightContent { get; private set; }

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            #if ENABLE_TEST_CLOUD
                        // requires Xamarin Test Cloud Agent
                        Xamarin.Calabash.Start();
            #endif

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            //change colors of Navigation Bar
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(51, 153, 255);
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes() { TextColor = UIColor.White });

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
            //UINavigationBar.Appearance.BarStyle = UIBarStyle.Black;

            return base.FinishedLaunching(app, options);
        }
    }
}
