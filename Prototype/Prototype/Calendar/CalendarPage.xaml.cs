using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using Syncfusion.SfSchedule.XForms;
using System.Diagnostics;
using UIKit;

namespace Prototype.Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        Calendar myCalendar = new Calendar("AIzaSyCUveAaJAyfqBoQUA0Z7iJXg4xQb8DHCG8", "LVIP-App", "shelbatron1000@gmail.com");
        public string calId;
        private double width;
        private double height;
        public CalendarPage()
        {
            InitializeComponent();

            Task.Run(() =>
            {
                myCalendar.GetEvents();

                Device.BeginInvokeOnMainThread(() =>
                {
                    cal.DataSource = myCalendar.Events;
                    calId = myCalendar.calendarId;
                });

            });

        }

        void Schedule_MonthInlineAppointmentTapped(object sender, MonthInlineAppointmentTappedEventArgs e)
        {
            var appointment = (e.Appointment as CalendarEvent);

            //Push the next page onto the Nav stack, pass it the appointment object
            CalendarEventDetails newPage = new CalendarEventDetails(appointment);
            Navigation.PushAsync(newPage);
        }

        private void Schedule_OnMonthInlineAppointmentLoadedEvent(object sender, MonthInlineAppointmentLoadedEventArgs args)
        {          
            //var appointment = (args.appointment as ScheduleAppointment);
            //Button button = new Button();
            //button.Text = appointment.Subject;
            //button.BackgroundColor = Color.Blue;
            //button.TextColor = Color.White;
            //args.view = button;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    Debug.WriteLine("Horizontal");
                    Device.BeginInvokeOnMainThread(() =>
                    {                     
                        //NavigationPage.SetHasNavigationBar(this, false);
                        cal.ScheduleView = ScheduleView.WeekView;
                        cal.TimeIntervalHeight = 50;
                        cal.ViewHeaderHeight = 55;

                        //Creating new instance of WeekViewSettings
                        WeekViewSettings weekViewSettings = new WeekViewSettings();
                        //Creating new instance of WeekLabelSettings
                        WeekLabelSettings weekLabelSettings = new WeekLabelSettings();
                        //Customizing date format
                        weekLabelSettings.DateFormat = "dd";
                        weekViewSettings.WeekLabelSettings = weekLabelSettings;
                        weekViewSettings.StartHour = 05;
                        cal.WeekViewSettings = weekViewSettings;

                        ViewHeaderStyle viewHeaderStyle = new ViewHeaderStyle();
                        viewHeaderStyle.DateFontSize = 15;
                        cal.ViewHeaderStyle = viewHeaderStyle;
                    });
                }
                else
                {
                    Debug.WriteLine("Vertical");
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        NavigationPage.SetHasNavigationBar(this, true);
                        cal.ScheduleView = ScheduleView.MonthView;
                    });

                }
            }
        }

        private void Schedule_CellTapped(object sender, CellTappedEventArgs e)
        {
            var appointment = (e.Appointment as CalendarEvent);

            if (cal.ScheduleView == ScheduleView.WeekView && appointment != null)
            {

                //Push the next page onto the Nav stack, pass it the appointment object
                CalendarEventDetails newPage = new CalendarEventDetails(appointment);
                Navigation.PushAsync(newPage);

            }
        }
    }
}