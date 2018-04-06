using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using Syncfusion.SfSchedule.XForms;

namespace Prototype.Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        Calendar myCalendar = new Calendar("AIzaSyCUveAaJAyfqBoQUA0Z7iJXg4xQb8DHCG8", "LVIP-App", "shelbatron1000@gmail.com");
        public CalendarPage()
        {
            InitializeComponent();

            GetEvents();

        }

        public void GetEvents()
        {
            myCalendar.GetEvents();
            cal.DataSource = myCalendar.scheduleAppointmentCollection;
            //cal.DataSource = myCalendar.Events;
        }

        //doesn't work with custom class
        void Schedule_MonthInlineAppointmentTapped(object sender, MonthInlineAppointmentTappedEventArgs e)
        {
            var appointment = (e.Appointment as object);
            DisplayAlert("Title", appointment.ToString(), "OK");
        }
    }
}