using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace Prototype.Calendar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalendarPage : ContentPage
	{
        Calendar myCalendar = new Calendar("AIzaSyCUveAaJAyfqBoQUA0Z7iJXg4xQb8DHCG8", "LVIP-App", "shelbatron1000@gmail.com");
        public CalendarPage()
        {
            InitializeComponent();

            getevents();

        }

        public void getevents()
        {
            myCalendar.GetEvents();
            cal.DataSource = myCalendar.Events;

        }


    }
}