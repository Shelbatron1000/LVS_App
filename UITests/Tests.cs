using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
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

        [Test]
        public void FLVSLoginTappedThenHomeTest()
        {
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Marked("11"));
            Assert.True(app.Query(c => c.WebView()) != null);
            app.Tap(x => x.Marked("Home"));
            app.WaitForElement(x => x.Marked("Welcome to Lee Virtual School!"), timeout: TimeSpan.FromSeconds(20));

        }

        [Test]
        public void ParentPortalTapped()
        {
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Marked("10"));
            Assert.True(app.Query(c => c.WebView()) != null);
        }

        [Test]
        public void ApplyTest()
        {
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Marked("9"));
            app.Tap(x => x.Text("Start"));
            app.Tap(x => x.Id("NoResourceEntry-42"));
            app.EnterText(x => x.Id("NoResourceEntry-42"), "Shelby");
            app.Tap(x => x.Id("NoResourceEntry-43"));
            app.EnterText(x => x.Id("NoResourceEntry-43"), "Middle");
            app.Tap(x => x.Id("NoResourceEntry-44"));
            app.EnterText(x => x.Id("NoResourceEntry-44"), "Smith");
            app.Tap(x => x.Text("03-14-2018"));
            app.Tap(x => x.Id("month_view"));
            app.Tap(x => x.Id("button1"));
            app.Tap(x => x.Id("NoResourceEntry-47"));
            app.EnterText(x => x.Id("NoResourceEntry-47"), "test@email.com");
            app.PressEnter();
            app.Tap(x => x.Id("NoResourceEntry-48"));
            app.EnterText(x => x.Id("NoResourceEntry-48"), "2395551111");
            app.PressEnter();
            app.Tap(x => x.Id("NoResourceEntry-49"));
            app.Tap(x => x.Text("Cell"));
            app.Tap(x => x.Id("NoResourceEntry-51"));
            app.EnterText(x => x.Id("NoResourceEntry-51"), "333 My Street");
            app.PressEnter();
            app.Tap(x => x.Id("NoResourceEntry-53"));
            app.EnterText(x => x.Id("NoResourceEntry-53"), "Fort  Myers");
            app.PressEnter();
            app.ScrollDownTo("Next");
            app.Tap(x => x.Id("NoResourceEntry-55"));
            app.Tap(x => x.Text("FL"));
            app.Tap(x => x.Id("NoResourceEntry-56"));
            app.EnterText(x => x.Id("NoResourceEntry-56"), "12345");
            app.PressEnter();
            app.Tap(x => x.Text("Next"));
            app.Tap(x => x.Id("NoResourceEntry-62"));
            app.EnterText(x => x.Id("NoResourceEntry-62"), "School");
            app.Tap(x => x.Id("NoResourceEntry-63"));
            app.EnterText(x => x.Id("NoResourceEntry-63"), "District");
            app.Tap(x => x.Id("NoResourceEntry-64"));
            app.EnterText(x => x.Id("NoResourceEntry-64"), "Lee");
            app.PressEnter();
            app.Tap(x => x.Id("NoResourceEntry-65"));
            app.Tap(x => x.Text("FL"));
            app.Tap(x => x.Id("NoResourceEntry-67"));
            app.ScrollDownTo("Eleventh", withinMarked: "select_dialog_listview");
            app.Tap(x => x.Text("Eleventh"));
            app.Tap(x => x.Text("Next"));
            app.Tap(x => x.Id("NoResourceEntry-73"));
            app.EnterText(x => x.Id("NoResourceEntry-73"), "Parent");
            app.Tap(x => x.Id("NoResourceEntry-74"));
            app.EnterText(x => x.Id("NoResourceEntry-74"), "Parent");
            app.Tap(x => x.Id("NoResourceEntry-75"));
            app.EnterText(x => x.Id("NoResourceEntry-75"), "Mother");
            app.Tap(x => x.Id("NoResourceEntry-76"));
            app.EnterText(x => x.Id("NoResourceEntry-76"), "2395551212");
            app.Tap(x => x.Id("NoResourceEntry-77"));
            app.Tap(x => x.Text("Cell"));
            app.Tap(x => x.Id("NoResourceEntry-78"));
            app.EnterText(x => x.Id("NoResourceEntry-78"), "test@email.com");
            app.PressEnter();
            app.Tap(x => x.Text("Next"));
            app.Tap(x => x.Id("NoResourceEntry-111"));
            app.EnterText(x => x.Id("NoResourceEntry-111"), "Reason");
            app.PressEnter();
            app.ScrollDownTo("Submit");
            app.Tap(x => x.Text("Submit"));
        }

      

    }
}

