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
    public partial class AppointmentsWebView : ContentPage
    {
        public AppointmentsWebView()
        {
            InitializeComponent();
            webView.Source = "https://www.genbook.com/bookings/slot/reservation/30106867?bookingContactId=2015816796&category=161745271";
        }
    }
}