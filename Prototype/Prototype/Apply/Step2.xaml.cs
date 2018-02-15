using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Prototype.Apply
{
    public partial class Step2 : ContentPage
    {
        StudentApp Application = new StudentApp();

        public Step2(StudentApp Application)
        {
            this.Application = Application;
            InitializeComponent();
            ObservableCollection<string> StateAbv = BuildStatesList();
            ObservableCollection<string> Grade = BuildGradeList();
            GradePicker.ItemsSource = Grade;
            StatePicker.ItemsSource = StateAbv;
        }
        public Step2()
        {
            InitializeComponent();
        }

        void LoadStep3(Object sender, EventArgs e)
        {
            //Push the next page, Step3, onto the Nav stack, pass it the Application object that was created here.
            Apply.Step3 newPage = new Apply.Step3(Application);
            Navigation.PushAsync(newPage);

        }

        void InsertInfo()
        {
            //Use this method to insert the info from the GUI into the Application object

        }

        public ObservableCollection<string> BuildGradeList()
        {
            ObservableCollection<string> Grades = new ObservableCollection<string>
            {
                "Kindergarten",
                "First",
                "Second",
                "Third",
                "Fourth",
                "Fifth",
                "Sixth",
                "Seventh",
                "Eighth",
                "Ninth",
                "Tenth",
                "Eleventh",
                "Twelfth",
                "None",
            };
            return Grades;
        }


        public ObservableCollection<string> BuildStatesList()
        {
            ObservableCollection<string> States = new ObservableCollection<string>
            {
                "AL",
                "AK",
                "AZ",
                "AR",
                "CA",
                "CO",
                "CT",
                "DE",
                "FL",
                "GA",
                "HI",
                "ID",
                "IL",
                "IN",
                "IA",
                "KS",
                "KY",
                "LA",
                "ME",
                "MD",
                "MA",
                "MI",
                "MN",
                "MS",
                "MO",
                "MT",
                "NE",
                "NV",
                "NH",
                "NJ",
                "NM",
                "NY",
                "NC",
                "ND",
                "OH",
                "OK",
                "OR",
                "PA",
                "RI",
                "SC",
                "SD",
                "TN",
                "TX",
                "UT",
                "VT",
                "VA",
                "WA",
                "WV",
                "WI",
                "WY"
            };
            return States;
        }

    }
}
