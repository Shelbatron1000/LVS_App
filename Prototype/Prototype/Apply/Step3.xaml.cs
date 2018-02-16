using System;
using System.Collections.Generic;
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
        }
        public Step3()
        {
            InitializeComponent();
        }

        void LoadStep4(Object sender, EventArgs e)
        {
            //Push the next page, Step3, onto the Nav stack, pass it the Application object that was created here.
            Apply.Step4 newPage = new Apply.Step4(Application);
            Navigation.PushAsync(newPage);

        }

        void InsertInfo()
        {
            //Use this method to insert the info from the GUI into the Application object
        }
    }
}
