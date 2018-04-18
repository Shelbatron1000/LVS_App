using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.SfSchedule.XForms;
using System.Diagnostics;

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
                        /* Switching to Week View
                         * 
                         * Current Bug on Week View: All Day Events show up as an extra day long.
                         * Should not be programmed to subtract a day in datetime because the overall standard
                         * is that all day events are from one day at 0:0:0 to the next day at 0:0:0.
                         * 
                         * Waiting on SyncFusion to fix this bug...
                         */

                        cal.ScheduleView = ScheduleView.WeekView;
                        cal.TimeIntervalHeight = 50;
                        cal.ViewHeaderHeight = 55;

                        //Creating new instance of WeekViewSettings
                        WeekViewSettings weekViewSettings = new WeekViewSettings();
                        //Creating new instance of WeekLabelSettings
                        WeekLabelSettings weekLabelSettings = new WeekLabelSettings();
                            
                        //custom UI
                        weekLabelSettings.DateFormat = "dd";
                        weekViewSettings.WeekLabelSettings = weekLabelSettings;
                        weekViewSettings.ShowAllDay = true;
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