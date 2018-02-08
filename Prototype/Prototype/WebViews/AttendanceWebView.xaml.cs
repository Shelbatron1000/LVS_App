using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttendanceWebView : ContentPage
    {

        public AttendanceWebView()
        {
             InitializeComponent();

            //This website is zoomed in when using a typical Xamarin.Forms WebView. 
            //So here I use a custom renderer to adjust the zoom options in the native code for each device.
            var hybridWebView = new HybridWebView
            {
                Url = "https://secureis.leeschools.net/LvipLogin/Forms/LVIPLogin.aspx?ReturnUrl=%2fLVIPlogin%2fforms%2flvipwelcome.aspx",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,

            };
            Content = hybridWebView;
        }


    }

}
