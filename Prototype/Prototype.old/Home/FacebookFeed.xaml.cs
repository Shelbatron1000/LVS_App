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
    public partial class FacebookFeed : ContentPage
    {
        public FacebookFeed()
        {
            InitializeComponent();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<iframe src=""https://www.facebook.com/plugins/page.php?href=https%3A%2F%2Fwww.facebook.com%2Fleevirtualschool%2F&tabs=timeline&width=340&height=500&small_header=false&adapt_container_width=true&hide_cover=false&show_facepile=false&appId"" width=""340"" height=""500"" style=""border:none;overflow:hidden"" scrolling=""no"" frameborder=""0"" allowTransparency=""true""></iframe>";
            webView.Source = htmlSource;

            webView.Navigating += async (sender, e) => {
                string url = e.Url;

                Debug.WriteLine(url);

                if (url.Equals("https://www.facebook.com/plugins/page.php?href=https%3A%2F%2Fwww.facebook.com%2Fleevirtualschool%2F&tabs=timeline&width=340&height=500&small_header=false&adapt_container_width=true&hide_cover=false&show_facepile=false&appId") || url.StartsWith("file://"))
                {
                    //do nothing and let it load

                } else
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