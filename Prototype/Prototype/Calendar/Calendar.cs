using System;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System.Collections.ObjectModel;

namespace Prototype.Calendar
{
    class Calendar
    {

        public ObservableCollection<CalendarEvent> Events = new ObservableCollection<CalendarEvent>();
        private string api, appName;
        public string calendarId;
        public Calendar(string api, string appName, string calendarId)
        {
            this.api = api;
            this.appName = appName;
            this.calendarId = calendarId;
        }

        public void GetEvents()
        {
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                ApiKey = api,
                ApplicationName = appName,

            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List(calendarId);
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            
            // List events.
            Events events = request.Execute();

            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    Events.Add(new CalendarEvent(eventItem.Summary, eventItem.Description, eventItem.Location,  
                        eventItem.Start, eventItem.End, eventItem.ICalUID, eventItem.Attachments, eventItem.HtmlLink, eventItem.Id));
                }
            }
            
        }

    }
}
