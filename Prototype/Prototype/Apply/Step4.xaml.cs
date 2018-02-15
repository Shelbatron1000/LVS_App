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
            }
        }

        void InsertInfo()
        {
            //use this methods to insert the information from the GUI into the Application object that was created here
            //At this point the entire application object should be built through all of the steps
        }

        void SubmitApplication(object sender, EventArgs e)
        {
            //Use this method to submit the application to LVS
        }

    }
}
