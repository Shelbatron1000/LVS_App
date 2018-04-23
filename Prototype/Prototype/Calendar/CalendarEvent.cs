using System;
using System.Collections.Generic;
using System.Diagnostics;
using Google.Apis.Calendar.v3.Data;
using Xamarin.Forms;

namespace Prototype.Calendar
{
    public class CalendarEvent
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string iCalUID { get; set; }
        public bool IsAllDay {get; set;}
        public IList<EventAttachment> Attachments { get; set; }
        public string Link { get; set; }
        public string Id { get; set; }
        public Color Color { get; set; }

        public CalendarEvent(string summary, string description, string location,  EventDateTime startTime, 
            EventDateTime endTime, string iCal, IList<EventAttachment> attachments, string link, string id, Color color)
        {
            if (summary != null)
            {
                Summary = summary;
            } else
            {
                Summary = "";
            }

            if (description != null)
            {
                Description = description;
            } else
            {
                Description = "";
            }

            if (location != null)
            {
                Location = location;
            } else
            {
                Location = "";
            }

            //check for all day events. All day events have DateTime as null but has a Date
            if(startTime.DateTime == null && startTime.Date != null)
            {
                StartTime = Convert.ToDateTime(startTime.Date.ToString() + " 0:0:0");
                IsAllDay = true;
            } else
            {
                StartTime = Convert.ToDateTime(startTime.DateTime);
                IsAllDay = false;
            }

            if (endTime.DateTime == null && endTime.Date != null)
            {                
                EndTime = Convert.ToDateTime(endTime.Date.ToString() + " 0:0:0");
                IsAllDay = true;
            }
            else
            {
                EndTime = Convert.ToDateTime(endTime.DateTime);
                IsAllDay = false;
            }
            //end 

            if (iCal != null)
            {
                iCalUID = iCal;
            } else
            {
                iCalUID = "";
            }

            Attachments = attachments;
            Link = link;
            Id = id;
            Color = color;
        }

        public string GetTimeString()
        {
            /* The AddDays(-1) is for all day events because the standard is that an all day event 
             * is from one day at 0:0:0 (midnight) to the next day at 0:0:0 (midnight). This is how
             * standard calendars process all day events. For text purposes below, we subtract a day
             * from the end day.
             */
            String time = "";

            if (IsAllDay == true && StartTime.Date == EndTime.Date.AddDays(-1)) //no times and only one day
            {
                time = StartTime.ToString("MM/dd/yy");

            }
            else if (IsAllDay == true && StartTime.Date != EndTime.Date.AddDays(-1)) //no times but more than one day
            {
                time = StartTime.ToString("MM/dd/yy") + " - " + EndTime.AddDays(-1).ToString("MM/dd/yy");

            }
            else if (IsAllDay == false && StartTime.Date != EndTime.Date) //has times but is more than a day
            {
                time = StartTime.ToString("MM/dd/yy h:mm tt") + " - " + EndTime.ToString("MM/dd/yy h:mm tt");

            }
            else if (IsAllDay == false && StartTime.Date == EndTime.Date) //has times and is in one day
            {
                time = StartTime.ToString("MM/dd/yy") + " \n" + StartTime.ToString("h:mm tt") + " - " + EndTime.ToString("h:mm tt");

            }
            else //default
            {
                time = StartTime.ToString("MM/dd/yy h:mm tt") + " - " + EndTime.ToString("MM/dd/yy h:mm tt");

            }

            return time;
        }
    }
}
