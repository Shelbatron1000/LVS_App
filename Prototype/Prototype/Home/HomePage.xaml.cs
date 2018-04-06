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
                }
            }


        }

        //label must have the phone number as its text!
        async void OnCall(object sender, EventArgs e)
        {
            Label lblClicked = (Label)sender;
            string txt = lblClicked.Text;
            string cleanedTxt = CleanStringOfNonDigits(txt);

            if (await this.DisplayAlert(
                    "Dial",
                    txt,
                    "Yes",
                    "No"))
            {
                Device.OpenUri(new Uri("tel://" + cleanedTxt));
            }

        }


        //clean label text of any non-numeric characters.
        private static Regex rxDigits = new Regex(@"[\d]+");
        private string CleanStringOfNonDigits(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            StringBuilder sb = new StringBuilder();
            for (Match m = rxDigits.Match(s); m.Success; m = m.NextMatch())
            {
                sb.Append(m.Value);
            }
            string cleaned = sb.ToString();
            return cleaned;
        }
        async void OnEmail(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                "Email",
                "Lee Virtual School",
                "Yes",
                "No"))
            {
                Device.OpenUri(new Uri("mailto:lvip@leeschools.net"));
            }

        }

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