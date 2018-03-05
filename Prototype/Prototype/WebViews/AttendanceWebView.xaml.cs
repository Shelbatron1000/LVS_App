using System;
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
        }


        private void openClicked(object sender, EventArgs e)
        {
            //open the current url in the native browser
            Device.OpenUri(new Uri("https://secureis.leeschools.net/LvipLogin/Forms/LVIPLogin.aspx?ReturnUrl=%2fLVIPlogin%2fforms%2flvipwelcome.aspx"));
        }

    }
}
