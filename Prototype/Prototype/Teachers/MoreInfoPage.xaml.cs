using System;
using System.Collections.Generic;
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

        }
        public MoreInfoPage()
        {
            InitializeComponent();
        }
    }
}
//