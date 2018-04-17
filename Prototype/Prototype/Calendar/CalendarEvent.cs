using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Google.Apis.Calendar.v3.Data;

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

        public CalendarEvent(string summary, string description, string location,  EventDateTime startTime, EventDateTime endTime, string iCal, IList<EventAttachment> attachments, string link, string id)
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
        }

        public string GetTimeString()
        {
            String time = "";

            if (IsAllDay == true && StartTime.Date == EndTime.Date) //no times and only one day
            {
                time = StartTime.ToString("MM/dd/yy");

            }
            else if (IsAllDay == true && StartTime.Date != EndTime.Date) //no times but more than one day
            {
                time = StartTime.ToString("MM/dd/yy") + " - " + EndTime.ToString("MM/dd/yy");

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

        public string GetCalAddLink()
        {
            string tempId = Id;

            if (Id.Contains("@"))
            {
                tempId = Id.Replace("@", "%40");
            }
            string eid = Link.Split('=')[1];

            //Currently opens event in native web browser (desktop version). This must happen because of Google/Android current bug that
            //results in an "Event Not Found" error if the event is opened in the Google Calendar App. Once the bug is resolved, then this
            //can be changed by replacing "render?" with "event?"
            return "https://calendar.google.com/render?action=TEMPLATE&tmeid=" + eid + "&tmsrc=" + tempId;

        }
    }
}
