using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Prototype.Apply
{
    public partial class Step1 : ContentPage
    {
        StudentApp Application = new StudentApp();
        public Step1()
        {
            InitializeComponent();
            ObservableCollection<string> StateAbv = BuildStatesList();
            ObservableCollection<string> Types = new ObservableCollection<string> 
            {
                "Home",
                "Cell",
                "Other"
            };
            PhoneTypePicker.ItemsSource = Types;
            StatePicker.ItemsSource = StateAbv;

        }

        void LoadStep2(Object sender, EventArgs e)
        {
            //Push the next page, Step2, onto the Nav stack, pass it the Application object that was created here.
            Apply.Step2 newPage = new Apply.Step2(Application);
            Navigation.PushAsync(newPage);
        }

        void InsertInfo()
        {
            //Use this method to insert the info from the GUI into the Application object
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
