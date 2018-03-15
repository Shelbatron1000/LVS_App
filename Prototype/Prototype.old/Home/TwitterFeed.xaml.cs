using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TwitterFeed : ContentPage
    {
        public TwitterFeed()
        {
            InitializeComponent();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @" <a class=""twitter-timeline"" href=""https://twitter.com/LeeVirtual?ref_src=twsrc%5Etfw""> Tweets by LeeVirtual</a><script async src=""https://platform.twitter.com/widgets.js"" charset=""utf-8""></script>";
            webView.Source = htmlSource;

            webView.Navigating += async (sender, e) => {
                string url = e.Url;

                Debug.WriteLine(url);
            
                if ( url.StartsWith("file://") || url.StartsWith("about:") || url.Equals("https://syndication.twitter.com/i/jot") || url.Equals("https://platform.twitter.com/jot.html"))
                {
                    //do nothing and let it load

                }
                else
                {
                    //prevent further navigation in the webview
                    e.Cancel = true;
                    if (await this.DisplayAlert(
                        "Navigate",
                        "Open this link in your web browser?",
                        "Yes",
                        "No"))
                    {
                        Device.OpenUri(new Uri(url));
                    }
                }


            };
        }
    }
}