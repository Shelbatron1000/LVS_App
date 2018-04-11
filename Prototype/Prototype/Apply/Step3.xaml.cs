using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Prototype.Apply
{
    public partial class Step3 : ContentPage
    {
        StudentApp Application = new StudentApp();
        public Step3(StudentApp Application)
        {
            this.Application = Application;
            InitializeComponent();
            ObservableCollection<string> Types = new ObservableCollection<string>
            {
                "Home",
                "Cell",
                "Other"
            };
            PhoneTypePicker.ItemsSource = Types;
        }
        public Step3()
        {
            InitializeComponent();
        }

        void LoadStep4(Object sender, EventArgs e)
        {
            //input validation
            InputValidation validate = new InputValidation();
            //first check for empty or null fields
            if (AnyFieldEmptyOrNull(validate)) //if fields are empty
            {
                DisplayAlert("Empty Field(s)", "Please input all information fields", "OK");
            }
            //next check for a valid email
            else if(!validate.ValidEmail(GuardianEmail)) //not a valid email
            {
                DisplayAlert("Invalid email", "Please input a valid email address", "OK");
                //next check for valid phone number
            }else if(!validate.ValidPhone(GuardianPhoneNumber)) //not a valid phone number
            {
                DisplayAlert("Invalid Phone Number", "Please input a valid 10 digit phone number", "OK");
            }
            else
            {

                //call insert info
                InsertInfo();

                //Push the next page, Step3, onto the Nav stack, pass it the Application object that was created here.
                Apply.Step4 newPage = new Apply.Step4(Application);
                Navigation.PushAsync(newPage);
            }
        }

        public bool AnyFieldEmptyOrNull(InputValidation validate)
        {
            if (validate.EmptyorNull(GuardianFirstName) ||
                validate.EmptyorNull(GuardianLastName) ||
                validate.EmptyorNull(GuardianRelationship) ||
                validate.EmptyorNull(GuardianPhoneNumber) ||
                validate.EmptyorNull(PhoneTypePicker) ||
                validate.EmptyorNull(GuardianEmail))
            {
                return true; //Meaning that a field IS empty or null
            }
            return false;
        }

        void InsertInfo()
        {
            Guardian guardian = new Guardian {
                FirstName = GuardianFirstName.Text,
                LastName = GuardianLastName.Text,
                Relationship = GuardianRelationship.Text,
                GuardianPhoneNumber = GuardianPhoneNumber.Text,
                GuardianPhoneType = PhoneTypePicker.SelectedItem.ToString(),
                EmailAddress = GuardianEmail.Text
            };
            Application.Guardian = guardian;
        }
    }
}
