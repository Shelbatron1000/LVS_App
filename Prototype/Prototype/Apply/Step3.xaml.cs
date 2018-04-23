using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Prototype.Apply
{
    public partial class Step3 : ContentPage
    {
        StudentApp Application = new StudentApp();

        /* In this constructor the first thing that happens is setting the 
        * application object that was passed from the previous page equal to
        * the application object declared in this class.
        * The InitializeComponent() method is required to load any UI page.
        * The 7 lines of code after the InitializeComponent call are all 
        * used to set up the information that will be displayed in the Picker
        * objects in the UI. Data binding is used to connect the 
        * ObservableCollection<string> objects to the Picker objects in the UI.
        */
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
        /*
         * A default constructor is required, even if it is never called.
        */
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

                //Push the next page, Step4, onto the Nav stack, pass it the Application object that was created here.
                Apply.Step4 newPage = new Apply.Step4(Application);
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
                guardianFirstName = GuardianFirstName.Text,
                guardianLastName = GuardianLastName.Text,
                relationship = GuardianRelationship.Text,
                guardianPhoneNumber = GuardianPhoneNumber.Text,
                guardianPhoneType = PhoneTypePicker.SelectedItem.ToString(),
                guardianEmailAddress = GuardianEmail.Text
            };
            Application.Guardian = guardian;
        }
    }
}
