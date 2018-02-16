using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                Status = "The application period is currently open.\n\nClick the start button below to begin.";
                StatusLabel.Text = Status;
                StartButton.IsVisible = true;
                StartButton.IsEnabled = true;
            }else
            {
                Status = "The application period is currently closed.\n\nApplications are not being accepted at this time." ; 
                StatusLabel.Text = Status;

            }
        }

        void StartApplication()
        {
            Apply.Step1 newPage = new Apply.Step1();
            Navigation.PushAsync(newPage);
        }

        //Use this method to query the server to see if the application period is active
        public bool IsActive()
        {
            return true;
        }
    }
}