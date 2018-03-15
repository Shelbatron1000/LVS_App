using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Prototype.Apply
{
    public partial class Step4 : ContentPage
    {
        StudentApp Application = new StudentApp();

        public Step4(StudentApp Application)
        {
            this.Application = Application;
            InitializeComponent();
        }
        public Step4()
        {
            InitializeComponent();
        }

        //This method will expand the GUI to include additional questions 5 and 6 regarding previous virtual schooling
        void AdditionalQuestions(object sender, EventArgs e)
        {
            if (Q4ResponseSwitch.IsToggled)
            {
                Q5.IsEnabled = true;
                Q5.IsVisible = true;
                Q5Response.IsEnabled = true;
                Q5Response.IsVisible = true;
                Q6.IsEnabled = true;
                Q6.IsVisible = true;
                Q6Response.IsEnabled = true;
                Q6Response.IsVisible = true;
                EndQ5Bar.IsVisible = true;
                EndQ6Bar.IsVisible = true;
            }else
            {
                Q5.IsEnabled = false;
                Q5.IsVisible = false;
                Q5Response.IsEnabled = false;
                Q5Response.IsVisible = false;
                Q6.IsEnabled = false;
                Q6.IsVisible = false;
                Q6Response.IsEnabled = false;
                Q6Response.IsVisible = false;
                EndQ5Bar.IsVisible = false;
                EndQ6Bar.IsVisible = false;
            }
        }

        void InsertInfo()
        {
            //use this methods to insert the information from the GUI into the Application object that was created here
            //At this point the entire application object should be built through all of the steps
        }

        void SubmitApplication(object sender, EventArgs e)
        {
            //input validation
            if (AnyFieldEmptyOrNull()) //if fields are empty
            {
                DisplayAlert("Empty Field(s)", "Please input all information fields", "OK");
            }
            //Use this method to submit the application to LVS
        }


        public bool AnyFieldEmptyOrNull()
        {
            InputValidation validate = new InputValidation();
            if ((Q4ResponseSwitch.IsToggled && validate.EmptyorNull(Q5Response)) ||
                validate.EmptyorNull(Q7Response)
            )
            {
                return true; //Meaning that a field IS empty or null
            }
            return false;
        }


    }
}
