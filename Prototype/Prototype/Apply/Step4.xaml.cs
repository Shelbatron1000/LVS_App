using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Diagnostics;

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

        //this method is used to display the date entry field in a easy to read
        // format, i.e. MM/DD/YYYY
        void DateUnfocusedFormat(object sender, EventArgs e)
        {
            InputValidation validate = new InputValidation();
            if (validate.EightDigitDate(Q6Response))
            {
                string date = Q6Response.Text;
                var temp = date.ToCharArray();
                date = String.Format("{0}{1}/{2}{3}/{4}{5}{6}{7}",
                                     temp[0], temp[1], temp[2], temp[3],
                                     temp[4], temp[5], temp[6], temp[7]);
                Q6Response.Text = date;
            }
            else
            {
                DisplayAlert("Invalid Date", "Please make sure the Date is valid (mm/dd/yyyy)", "OK");
            }

        }

        //this method is used to change the display of the date in the DOB entry
        //from MM/DD/YYYY to MMDDYYYY removing the /'s
        void DateFocusedFormat(object sender, EventArgs e)
        {
            if (Q6Response.Text != null)
            {
                var temp = Q6Response.Text.Split('/');
                Q6Response.Text = "";
                foreach (string part in temp)
                {
                    Q6Response.Text += part;
                }
            }

        }

        void InsertInfo()
        {
            EligibilityQuestions eQ = new EligibilityQuestions {
                EQResponse1 = YesOrNo(Q1ResponseSwitch),
                EQResponse2 = YesOrNo(Q2ResponseSwitch),
                EQResponse3 = YesOrNo(Q3ResponseSwitch),
                EQResponse4 = YesOrNo(Q4ResponseSwitch),
                EQResponse8 = YesOrNo(Q8ResponseSwitch)
            };
            if(Q4ResponseSwitch.IsToggled && Q5Response != null)
            {
                eQ.EQResponse5 = Q5Response.Text;
            }
            if (Q4ResponseSwitch.IsToggled && Q6Response != null)
            {
                eQ.EQResponse6 = Q6Response.Text;
            }
            eQ.EQResponse7 = Q7Response.Text;
            Application.Questions = eQ;
            
            //At this point the entire application object should be built throughout all of the steps
        }

        void SubmitApplication(object sender, EventArgs e)
        {
            //input validation
            if (AnyFieldEmptyOrNull()) //if fields are empty
            {
                DisplayAlert("Empty Field(s)", "Please input all information fields", "OK");
            }           

            //inserting info from the GUI into the StudentApp object
            InsertInfo();

            //converting the StudentApp object to a JSON object
            var JSONApplication = JsonConvert.SerializeObject(Application);
            Debug.WriteLine(JSONApplication);
        }


        public bool AnyFieldEmptyOrNull()
        {
            InputValidation validate = new InputValidation();
            if ((Q4ResponseSwitch.IsToggled && (validate.EmptyorNull(Q5Response) || validate.EmptyorNull(Q6Response))) ||
                 validate.EmptyorNull(Q7Response))
            {
                return true; //Meaning that a field IS empty or null
            }
            return false;
        }

        public string YesOrNo (Switch toggle)
        {
            if(toggle.IsToggled)
            {
                return "YES";
            }else{
                return "NO";
            }
        }


    }
}
