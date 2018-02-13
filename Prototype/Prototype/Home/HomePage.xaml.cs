using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async void OnNavigate(object sender, EventArgs e)
        {
            Label lblClicked = (Label)sender;
            string address = lblClicked.Text;

            if (await this.DisplayAlert(
                    "Navigate",
                    address,
                    "Yes",
                    "No"))
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        Device.OpenUri(
                          new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(address))));
                        break;
                    case Device.Android:
                        Device.OpenUri(
                          new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(address))));
                        break;
                    case Device.UWP:
                    case Device.WinPhone:
                        Device.OpenUri(
                          new Uri(string.Format("bingmaps:?where={0}", Uri.EscapeDataString(address))));
                        break;
                }
            }

            
        }

        //label must have the phone number as its text!
        async void OnCall(object sender, EventArgs e)
        {
            Label lblClicked = (Label)sender;
            string txt = lblClicked.Text;
            //string cleanedTxt = CleanStringOfNonDigits(txt);

            if (await this.DisplayAlert(
                    "Dial",
                    txt,
                    "Yes",
                    "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                    dialer.Dial(txt);
            }
            
        }

        /*
         * I thought the iOS simulator wasn't making a phone call because of the txt having
         * special characters. But it turns out you can't test making a phone call on
         * an iOS simulator
         */

        //clean label text of any non-numeric characters.
        //private static Regex rxDigits = new Regex(@"[\d]+");

        //private string CleanStringOfNonDigits(string s)
        //{
        //    if (string.IsNullOrEmpty(s)) return s;
        //    StringBuilder sb = new StringBuilder();
        //    for (Match m = rxDigits.Match(s); m.Success; m = m.NextMatch())
        //    {
        //        sb.Append(m.Value);
        //    }
        //    string cleaned = sb.ToString();
        //    return cleaned;
        //}

        private void TwitterClicked(object sender, EventArgs e)
        {
            Home.TwitterFeed newPage = new Home.TwitterFeed();

            Navigation.PushAsync(newPage);
        }

        private void FacebookClicked(object sender, EventArgs e)
        {
            Home.FacebookFeed newPage = new Home.FacebookFeed();

            Navigation.PushAsync(newPage);
        }
    }
}