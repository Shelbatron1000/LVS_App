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
            /* In this constructor the first thing that happens is setting the 
            * application object that was passed from the previous page equal to
            * the application object declared in this class.
            * The InitializeComponent() method is required to load any UI page.
            * The 4 lines of code after the InitializeComponent call are all 
            * used to set up the information that will be displayed in the Picker
            * objects in the UI. Data binding is used to connect the 
            * ObservableCollection<string> objects to the Picker objects in the UI.
            */
            this.Application = Application;
            InitializeComponent();
            ObservableCollection<string> StateAbv = BuildStatesList();
            ObservableCollection<string> Grade = BuildGradeList();
            GradePicker.ItemsSource = Grade;
            StatePicker.ItemsSource = StateAbv;
        }
        /*
         * A default constructor is required, even if it is never called.
        */
        public Step2()
        {
            InitializeComponent();
        }

        void LoadStep3(Object sender, EventArgs e)
        {
            //input validation
            if (AnyFieldEmptyOrNull()) //if fields are empty
            {
                DisplayAlert("Empty Field(s)", "Please input all information fields", "OK");
            }
            else
            {

                //call insert info
                InsertInfo();

                //Push the next page, Step3, onto the Nav stack, pass it the Application object that was created here.
                Apply.Step3 newPage = new Apply.Step3(Application);
                Navigation.PushAsync(newPage);
            }
        }

        /*
        * The following method is used to check each Entry or Picker in the UI
        * for content. It calls the EmptyOrNull method from the InputValidation
        * object to determine if the Entry or Picker contains an empty string or
        * is still null from never being manipulated. The method returns true 
        * if a field is either empty or still null. If all of the fields in the
        * IF clause are filled with a string it will return false.
        */
        public bool AnyFieldEmptyOrNull()
        {
            InputValidation validate = new InputValidation();
            if (validate.EmptyorNull(SchoolName) ||
                validate.EmptyorNull(SchoolDistrict) || 
                validate.EmptyorNull(SchoolCounty) ||
                validate.EmptyorNull(StatePicker) ||
                validate.EmptyorNull(GradePicker))
            {
                return true; //Meaning that a field IS empty or null
            }
            return false;
        }

        /*
         * The following method is used to take the information entered into the UI
         * and insert it into the application object. This method creates a new 
         * SchoolInfo object and takes each field from the UI and sets the corresponding
         * field of the object equal to the information entered. The method lastly
         * sets the SchoolInfo object belonging to the Application object equal to 
         * this newly created SchoolInfo.
        */
        void InsertInfo()
        {
            SchoolInfo schoolInfo = new SchoolInfo { 
                schoolName = SchoolName.Text,
                district = SchoolDistrict.Text,
                county = SchoolCounty.Text,
                districtState = StatePicker.SelectedItem.ToString(),
                grade = GradePicker.SelectedItem.ToString()
            };
            Application.LastSchool = schoolInfo;
        }

        /*
        * The following method builds a list of all grade levels so that they 
        * can be bound to the corresponding Picker object in the UI.
        */
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

        /*
        * The following method builds a list of all of the state abbreviations
        * so that they can be bound to the corresponding Picker object in the UI.
        */
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
