using System;
using System.Collections.Generic;
using System.Text;
using Google.Apis.Calendar.v3.Data;

namespace Prototype.Calendar
{
    public struct CalendarEvent
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string iCalUID { get; set; }
        public string Color { get; set; }
        public bool IsAllDay {get; set;}

        public CalendarEvent(string summary, string description, string location,  EventDateTime startTime, EventDateTime endTime, string iCal, string color)
        {
            Summary = summary;
            Description = description;
            Location = location;

            //check for all day events. All dat events have DateTime as null but has a Date
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
            iCalUID = iCal;
            Color = color;
        }
    }
}
