using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Text;
using System.Diagnostics;

namespace Prototype.Apply
{
    public partial class Step1 : ContentPage
    {
        StudentApp Application = new StudentApp();
        public Step1(StudentApp Application)
        {
            /* In this constructor the first thing that happens is setting the 
             * application object that was passed from the previous page equal to
             * the application object declared in this class.
             * The InitializeComponent() method is required to load any UI page.
             * The 9 lines of code after the InitializeComponent call are all 
             * used to set up the information that will be displayed in the Picker
             * objects in the UI. Data binding is used to connect the 
             * ObservableCollection<string> objects to the Picker objects in the UI.
            */
            this.Application = Application;
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

        /*
         * A default constructor is required, even if it is never called.
        */
        public Step1()
        {
            InitializeComponent();
        }

        //this method is used to display the date entry field in a easy to read
        // format, i.e. MM/DD/YYYY
        void DateUnfocusedFormat(object sender, EventArgs e)
        {
            InputValidation validate = new InputValidation();
            if(validate.EightDigitDate(DOB)){
                string date = DOB.Text;
                var temp = date.ToCharArray();
                date = String.Format("{0}{1}/{2}{3}/{4}{5}{6}{7}",
                                     temp[0], temp[1], temp[2], temp[3],
                                     temp[4], temp[5], temp[6], temp[7]);
                DOB.Text = date;
            }else
            {
                DisplayAlert("Invalid Date", "Please make sure the Date is valid (mm/dd/yyyy)", "OK");
            }

        }

        //this method is used to change the display of the date in the DOB entry
        //from MM/DD/YYYY to MMDDYYYY removing the /'s
        void DateFocusedFormat(object sender, EventArgs e)
        {
            if(DOB.Text != null){
                var temp = DOB.Text.Split('/');
                DOB.Text = "";
                foreach(string part in temp)
                {
                    DOB.Text += part;
                }
            }

        }

        void LoadStep2(Object sender, EventArgs e)
        {
            //input validation
            InputValidation validate = new InputValidation();

            //first check for any empty or null fields
            if(AnyFieldEmptyOrNull(validate)) //if fields are empty
            {
                DisplayAlert("Empty Field(s)", "Please input all information fields", "OK");
            }
            //check for valid date
            else if(!validate.ValidDate(DOB))
            {
                DisplayAlert("Invalid Date", "Please make sure the Date is valid (mm/dd/yyyy)", "OK");
            }
            //next check for a valid email
            else if(!validate.ValidEmail(Email)) //not a valid email
            {
                DisplayAlert("Invalid email", "Please input a valid email address", "OK");
            }
            //next check for valid phone number
            else if(!validate.ValidPhone(PhoneNumber))
            {
                DisplayAlert("Invalid Phone Number", "Please input a valid 10 digit phone number", "OK");
            }
            //next check for valid zip code
            else if(!validate.ValidZip(ZipCode)) //not a valid ZIP
            {
                DisplayAlert("Invalid Zip Code", "Please input a valid 5 digit ZIP Code", "OK");
            }
            else
            {

                //call insert info
                InsertInfo();

                //Push the next page, Step2, onto the Nav stack, pass it the Application object that was created here.
                Apply.Step2 newPage = new Apply.Step2(Application);
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
        public bool AnyFieldEmptyOrNull(InputValidation validate)
        {
            if(validate.EmptyorNull(FirstName) ||
               validate.EmptyorNull(MiddleName) || //clarify if this is allowed to be empty
               validate.EmptyorNull(LastName) ||
               validate.EmptyorNull(DOB) ||
               validate.EmptyorNull(Email) ||
               validate.EmptyorNull(PhoneNumber) ||
               validate.EmptyorNull(PhoneTypePicker) ||
               validate.EmptyorNull(Street) ||
               validate.EmptyorNull(City) ||
               validate.EmptyorNull(StatePicker) ||
               validate.EmptyorNull(ZipCode)
            )
            {
                return true; //Meaning that a field IS empty or null
            }
            return false;
        }

        /*
         * The following method is used to take the information entered into the UI
         * and insert it into the application object. This method creates a new 
         * Student object and takes each field from the UI and sets the corresponding
         * field of the object equal to the information entered. The method lastly
         * sets the student object belonging to the Application object equal to 
         * this newly created student.
        */
        void InsertInfo()
        {
            Student student = new Student
            {
                firstName = FirstName.Text,
                middleName = MiddleName.Text,
                lastName = LastName.Text,
                dateOfBirth = SwapDate(DOB.Text),
                studentEmail = Email.Text,
                phoneNumber = PhoneNumber.Text,
                phoneType = PhoneTypePicker.SelectedItem.ToString(),
                streetAddress = Street.Text,
                unitNumber = Unit.Text,
                city = City.Text,
                state = StatePicker.SelectedItem.ToString(),
                zipCode = ZipCode.Text
            };
            Application.Student = student;
        }

       private string SwapDate(String date)
        {
            string newDate = "";
            var temp = date.Split('/');
            newDate = temp[2] + "-" + temp[0] + "-" + temp[1];
            return newDate;
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
