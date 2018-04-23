using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototype.Apply;

namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplyPage : ContentPage
    {
        string Status { get; set; }
        public ApplyPage()
        {
            InitializeComponent();
            if(IsActive())
            {
                Status = "The application period is currently open.\n\nClick below to begin.";
                StatusLabel.Text = Status;
                ButtonsLayout.IsVisible = true;
                ButtonsLayout.IsEnabled = true;
            }else
            {
                Status = "The application period is currently closed.\n\nApplications are not being accepted at this time." ; 
                StatusLabel.Text = Status;

            }
        }

        /* The StartApplication method is triggered when the Start button on the
         * UI is pressed. The method creates a new Application object and passes
         * that on to the constructor of the Step1 page. After the Step1 object
         * is created it is pushed to the navigation stack and the UI will switch
         * to the Step1 page.
        */
        void StartApplication()
        {
            StudentApp Application = new StudentApp();
            Apply.Step1 newPage = new Apply.Step1(Application);
            Navigation.PushAsync(newPage);
        }


        //Use this method to query the server to see if the application period is active
        public bool IsActive()
        {
            /* It was said that the application period was not always active. To
             * determine if the period is active or not this method needs to be
             * expanded upon.
             * In this method the best thing would be to query the database or a
             * location that houses a binary YES or NO value of the application
             * being active or not active. After retrieving that binary value 
             * an IF Else block could return true or false based upon the value
             * received. For testing and demonstration purposes the method
             * currently always returns true. The return value of this method 
             * will determine what is displayed on the UI when someone navigates
             * to the Apply page from the menu.
            */
            return true;
        }
    }
}