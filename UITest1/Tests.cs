using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    /*For Android and on Windows, you can use the Xamarin Test Recorder to create a UITest*/
    //[TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)] //Cannot test on Windows
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
        // Invoke the REPL to explore the user interface within a test method
        //app.Repl(); //when it pops up, type "tree"

        [Test]
        public void AppLaunchesTest()
        {
            Assert.DoesNotThrow(() => {app.Screenshot("First screen.");}); 
        }

        [Test]
        public void AttendanceTappedTest()
        {
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Marked("1"));
            Assert.True(app.Query(c => c.WebView()) != null);
        }

        [Test]
        public void TeacherDataLoadedTest()
        {
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Marked("3"));
            app.Tap(x => x.Marked("5"));
            int ElemListLength = app.Query(q => q.Id("NoResourceEntry-34").Child()).Length;           
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Marked("6"));
            int SecListLength = app.Query(q => q.Id("NoResourceEntry-45").Child()).Length;
            Assert.True(ElemListLength > 0 && SecListLength > 0);
        }

        [Test]
        public void ResourcesTappedTest()
        {
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Marked("8"));
            Assert.True(app.Query(c => c.WebView()) != null);
        }

    }
}

