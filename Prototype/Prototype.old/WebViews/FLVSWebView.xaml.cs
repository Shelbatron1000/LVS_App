﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.WebViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FLVSWebView : ContentPage
    {
        private static string currentUrl = "https://login.flvs.net/";

        public FLVSWebView()
        {
            InitializeComponent();
        }

        private void backClicked(object sender, EventArgs e)
        {
            // Check to see if there is anywhere to go back to
            if (Browser.CanGoBack)
            {
                Browser.GoBack();
            }
        }

        private void openClicked(object sender, EventArgs e)
        {
            //open the current url in the native browser
            Device.OpenUri(new Uri(currentUrl));
        }

        private void forwardClicked(object sender, EventArgs e)
        {
            // Check to see if there is anywhere to go forward to
            if (Browser.CanGoForward)
            {
                Browser.GoForward();
            }
        }

        public void OnNavigatedHandler(object sender, WebNavigatedEventArgs e)
        {
            //keep track of what url the user is currently on
            currentUrl = e.Url;
        }
    }
}