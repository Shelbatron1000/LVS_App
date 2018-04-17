using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Prototype.Teachers
{
    public partial class MoreInfoPage : ContentPage
    {
        TeacherInfo.Teacher Teacher = new TeacherInfo.Teacher();
        public MoreInfoPage(TeacherInfo.Teacher Teacher)
        {
            this.Teacher = Teacher;
            InitializeComponent();
            TeacherName.Text = Teacher.Name;
            TeacherPhone.Text = Teacher.Phone;
            TeacherEmail.Text = Teacher.Email;
            TeacherHours.Text = Teacher.OfficeHours;
            TeacherNotes.Text = Teacher.Notes;
            this.Title = Teacher.Name;

        }
        public MoreInfoPage()
        {
            InitializeComponent();
        }

        public void ToGenBook(object sender, EventArgs e)
        {
            if(Teacher.School.Equals("Elementary"))
            {
                Navigation.PushAsync(new WebViews.GenBookElementaryWebView());
            } else
            {
                Navigation.PushAsync(new WebViews.GenBookSecondaryWebView());
            }
            
        }

        //label must have the phone number as its text!
        async void OnCall(object sender, EventArgs e)
        {
            Label lblClicked = (Label)sender;
            string txt = lblClicked.Text;
            string cleanedTxt = CleanStringOfNonDigits(txt);

            if (await this.DisplayAlert(
                    "Dial",
                    txt,
                    "Yes",
                    "No"))
            {
                Device.OpenUri(new Uri("tel://" + cleanedTxt));
            }

        }

        async void OnEmail(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                "Email",
                Teacher.Email,
                "Yes",
                "No"))
            {
                Device.OpenUri(new Uri("mailto:"+Teacher.Email));
            }

        }

        //clean label text of any non-numeric characters.
        private static Regex rxDigits = new Regex(@"[\d]+");
        private string CleanStringOfNonDigits(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (Match m = rxDigits.Match(s); m.Success; m = m.NextMatch())
            {
                sb.Append(m.Value);
            }
            string cleaned = sb.ToString();
            return cleaned;
        }

    }
}
//