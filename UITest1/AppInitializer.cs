using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .ApkFile(@"C:\Users\shelb\VisualStudio2017_Projects\Prototype\Prototype\Prototype.Android\bin\Release\Prototype.Prototype.apk")
                    .StartApp();
                    
            }else if (platform == Platform.iOS)
            {
                return ConfigureApp
                .iOS
                // device UUID is unique to each computer. Type "instruments -s devices" in terminal to see available UUIDs
                //.DeviceIdentifier("8C7F025A-82B0-BC5E-4AC0BA04565A") //iphone 6s 9.3 Simulator
                .StartApp();
            } else
            {
                return null;
            }
        }
    }
}

