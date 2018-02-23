using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    /*For Android and on Windows, you can use the Xamarin Test Recorder to create a UITest*/
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)] //Cannot test on Windows
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        /*Demo Tests - as of now our program has very little testable elements*/

        [Test]
        public void AppLaunches()
        {
            //app.Screenshot("First screen.");
        }


        [Test]
        public void AddressTapped()
        {
            // Invoke the REPL so that we can explore the user interface
            //app.Repl();
            //when it pops up, type "tree"
            app.Tap(x => x.Marked("addressText"));
            app.Tap(x => x.Id("button1"));
        }

    }
}

