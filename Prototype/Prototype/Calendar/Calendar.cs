using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Xml;
using Syncfusion.SfSchedule.XForms;

namespace Prototype.Calendar
{
    class Calendar
    {

        public List<CalendarEvent> Events = new List<CalendarEvent>();
        public ScheduleAppointmentCollection scheduleAppointmentCollection = new ScheduleAppointmentCollection();
        private string api, appName, calendarId;
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
            //request.MaxResults = 28;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;


            // List events.          
            Events events = request.Execute();
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    //Creating new event   
                    ScheduleAppointment appointment = new ScheduleAppointment();

                    if (eventItem.Summary != null)
                    {
                        appointment.Subject = eventItem.Summary;
                    }
                    else
                    {
                        appointment.Subject = "";
                    }

                    if (eventItem.Description != null)
                    {
                        appointment.Notes = eventItem.Description;
                    }
                    else
                    {
                        appointment.Notes = "";
                    }

                    if (eventItem.Location != null)
                    {
                        appointment.Location = eventItem.Location;
                    }
                    else
                    {
                        appointment.Location = "";
                    }

                    //check for all day events. All dat events have DateTime as null but has a Date
                    if (eventItem.Start.DateTime == null && eventItem.Start.Date != null)
                    {
                        appointment.StartTime = Convert.ToDateTime(eventItem.Start.Date.ToString() + " 0:0:0");
                        appointment.IsAllDay = true;
                    }
                    else
                    {
                        appointment.StartTime = Convert.ToDateTime(eventItem.Start.DateTime);
                        appointment.IsAllDay = false;
                    }

                    if (eventItem.End.DateTime == null && eventItem.End.Date != null)
                    {
                        appointment.EndTime = Convert.ToDateTime(eventItem.End.Date.ToString() + " 0:0:0");
                        appointment.IsAllDay = true;
                    }
                    else
                    {
                        appointment.EndTime = Convert.ToDateTime(eventItem.End.DateTime);
                        appointment.IsAllDay = false;
                    }
                    //end                     
                    scheduleAppointmentCollection.Add(appointment);

                    //Events.Add(new CalendarEvent(eventItem.Summary, eventItem.Description, eventItem.Location,  eventItem.Start, eventItem.End, eventItem.ICalUID));
                }
            }
            
        }

    }
}
