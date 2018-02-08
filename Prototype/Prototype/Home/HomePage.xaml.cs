using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @" <a class=""twitter-timeline"" href=""https://twitter.com/LeeVirtual?ref_src=twsrc%5Etfw""> Tweets by LeeVirtual</a><script async src=""https://platform.twitter.com/widgets.js"" charset=""utf-8""></script>";
            webView.Source = htmlSource;
        }
    }
}