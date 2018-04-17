using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Prototype.Apply
{
    public partial class Step1 : ContentPage
    {
        StudentApp Application = new StudentApp();
        public Step1(StudentApp Application)
        {
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
        public Step1()
        {
            InitializeComponent();
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


                //Push the next page, Step2, onto the Nav stack, pass it the Application object that was created here.
                Apply.Step2 newPage = new Apply.Step2(Application);
                Navigation.PushAsync(newPage);

            }
        }

        public bool AnyFieldEmptyOrNull(InputValidation validate)
        {
            if(validate.EmptyorNull(FirstName) ||
               validate.EmptyorNull(MiddleName) || //clarify if this is allowed to be empty
               validate.EmptyorNull(LastName) ||
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

        void InsertInfo()
        {
            Student student = new Student
            {
                FirstName = FirstName.Text,
                MiddleName = MiddleName.Text,
                LastName = LastName.Text,
                DOB = DOB.Date.ToString(),
                StudentEmail = Email.Text,
                PhoneNumber = PhoneNumber.Text,
                PhoneType = PhoneTypePicker.SelectedItem.ToString(),
                StreetAddress = Street.Text,
                UnitNumber = Unit.Text,
                City = City.Text,
                State = StatePicker.SelectedItem.ToString(),
                ZipCode = ZipCode.Text
            };
            Application.Student = student;
        
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
