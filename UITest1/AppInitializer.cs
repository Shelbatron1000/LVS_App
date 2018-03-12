using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    public class AppInitializer
    {
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                   // .ApkFile(@"C:\Users\shelb\VisualStudio2017_Projects\Prototype\Prototype\Prototype.Android\bin\Release\Prototype.Prototype.apk")
                    //.ApkFile(@"/Users/derekbailey/Projects/Shelbatron1000/LVS_App/Prototype/Prototype.Android/bin/Release/Prototype.apk")
                    .StartApp();
                    
            }else if (platform == Platform.iOS)
            {
                return ConfigureApp
                    .iOS
                    .EnableLocalScreenshots()
                    .DeviceIdentifier("08C55598-A631-4BED-94E6-D5CB9FD054B1") //iphone X 11.2 Simulator
                    .StartApp();
            } else
            {
                return null;
            }
        }
    }
}

