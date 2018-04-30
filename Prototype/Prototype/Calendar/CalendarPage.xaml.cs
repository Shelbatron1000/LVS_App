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
        Calendar myCalendar;
        public string calId;
        private double width;
        private double height;
        public CalendarPage()
        {
            InitializeComponent();
            calId = myCalendar.calendarId;

            //Customizing background color
            MonthViewSettings monthViewSettings = new MonthViewSettings();
            monthViewSettings.TodayBackground = Color.FromHex("#36b6e5");
            cal.MonthViewSettings = monthViewSettings;

            Task.Run(() =>
            {
                myCalendar.GetEvents();

                Device.BeginInvokeOnMainThread(() =>
                {
                    cal.DataSource = myCalendar.Events;
                });
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            (App.Current.MainPage as MasterDetailPage).IsGestureEnabled = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (App.Current.MainPage as MasterDetailPage).IsGestureEnabled = false;
        }
        void Schedule_MonthInlineAppointmentTapped(object sender, MonthInlineAppointmentTappedEventArgs e)
        {
            var appointment = (e.Appointment as CalendarEvent);

            //Push the next page onto the Nav stack, pass it the appointment object
            CalendarEventDetails newPage = new CalendarEventDetails(appointment, myCalendar.calendarId);
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
                         * SyncFusion says this bug should be fixed in their update at the end of May 2018 so 
                         * please update the NuGet package then.
                         * 
                         * https://www.syncfusion.com/forums/137099/all-day-event-rendering-as-two-days-in-week-view
                         * 
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
                CalendarEventDetails newPage = new CalendarEventDetails(appointment, calId);
                Navigation.PushAsync(newPage);

            }
        }
    }
}