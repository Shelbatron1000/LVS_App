using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacebookFeed : ContentPage
    {
        string currentUrl = "";
        public FacebookFeed()
        {
            InitializeComponent();

            //max iframe size is 500 width by 340 height.
            if (Application.Current.MainPage.Width <= 500 && Application.Current.MainPage.Height <= 340)
            {
                Browser.Source = "https://www.facebook.com/plugins/page.php?href=https%3A%2F%2Fwww.facebook.com%2Fleevirtualschool%2F&tabs=timeline&width=340&height=500&small_header=false&adapt_container_width=true&hide_cover=false&show_facepile=true&appId";
                currentUrl = "https://www.facebook.com/plugins/page.php?href=https%3A%2F%2Fwww.facebook.com%2Fleevirtualschool%2F&tabs=timeline&width=340&height=500&small_header=false&adapt_container_width=true&hide_cover=false&show_facepile=true&appId";
            } else
            {
                Browser.Source = "https://www.facebook.com/leevirtualschool/";
                currentUrl = "https://www.facebook.com/leevirtualschool/";
            }

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