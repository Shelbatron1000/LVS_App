using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarEventDetails : ContentPage
    {
        CalendarEvent thisEvent;
        private double width;
        private double height;
        bool hasDescription = false;
        public CalendarEventDetails()
        {
            InitializeComponent();
        }

        public CalendarEventDetails(CalendarEvent myEvent)
        {
            InitializeComponent();
            thisEvent = myEvent;
            if(thisEvent.Description != "")
            {
                hasDescription = true;
            }
            EventName.Text = thisEvent.Summary;
            EventLocation.Text = thisEvent.Location;
            EventTime.Text = thisEvent.GetTimeString();
            HtmlWebViewSource html = new HtmlWebViewSource
            {
                Html = thisEvent.Description
            };

            EventDescription.Source = html;

            HasAttachments();
        }

        //check for any event attachments, and if there are any, add them to the layout. 
        public void HasAttachments()
        {
            if (thisEvent.Attachments != null)
            {
                EventAttachments.IsVisible = true;
                EventAttachments.Text = "Attachments (" + thisEvent.Attachments.Count + "): ";
                AttachmentPicker.IsVisible = true;
                AttachmentButton.IsVisible = true;
                foreach (EventAttachment e in thisEvent.Attachments)
                {
                    AttachmentPicker.Items.Add(e.Title);
                }
                AttachmentPicker.SelectedIndex = 0;
            }
        }

        private void OpenAttachment(object sender, EventArgs e)
        {
            int index = AttachmentPicker.SelectedIndex;
            Device.OpenUri(new Uri(thisEvent.Attachments.ElementAt(index).FileUrl));
        }

        public void OnCalAdd(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(thisEvent.GetCalAddLink()));
        }

        async void OnNavigate(object sender, EventArgs e)
        {
            Label lblClicked = (Label)sender;
            string address = lblClicked.Text;

            if (await this.DisplayAlert(
                    "Navigate",
                    address,
                    "Yes",
                    "No"))
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        Device.OpenUri(
                          new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(address))));
                        break;
                    case Device.Android:
                        Device.OpenUri(
                          new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(address))));
                        break;
                }
            }
        }

        async Task OnWebNavigating(object sender, WebNavigatingEventArgs e)
        {
            string url = e.Url;
            Debug.WriteLine(url);

            if (url.StartsWith("file://"))
            {
                //do nothing and let it load. This is the initial html description.
            }
            else
            {
                //prevent further navigation in the webview
                e.Cancel = true;
                if (await this.DisplayAlert(
                    "Navigate",
                    "Open this link in your web browser?",
                    "Yes",
                    "No"))
                {
                    Device.OpenUri(new Uri(url));
                }
            }
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
                        if (hasDescription)
                        {
                            StackOuter.Orientation = StackOrientation.Horizontal;
                        }
                    });
                }
                else
                {
                    Debug.WriteLine("Vertical");
                    Device.BeginInvokeOnMainThread(() =>
                    {
                       StackOuter.Orientation = StackOrientation.Vertical;
                    });

                }
            }
        }
    }
}