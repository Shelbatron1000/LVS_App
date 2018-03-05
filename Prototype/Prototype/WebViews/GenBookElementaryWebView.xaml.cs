using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.WebViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenBookElementaryWebView : ContentPage
    {
        private static string currentUrl = "https://www.genbook.com/bookings/slot/reservation/30106867?bookingContactId=1464927247&amp;category=443131274";

        public GenBookElementaryWebView()
        {
            InitializeComponent();
        }

        private void backClicked(object sender, EventArgs e)
        {
            // Check to see if there is anywhere to go back to
            if (Browser.CanGoBack)
            {
                Browser.GoBack();
            }
        }

        private void openClicked(object sender, EventArgs e)
        {
            //open the current url in the native browser
            Device.OpenUri(new Uri(currentUrl));
        }

        private void forwardClicked(object sender, EventArgs e)
        {
            // Check to see if there is anywhere to go forward to
            if (Browser.CanGoForward)
            {
                Browser.GoForward();
            }
        }

        public void OnNavigatedHandler(object sender, WebNavigatedEventArgs e)
        {
            //keep track of what url the user is currently on
            currentUrl = e.Url;
        }
    }
}