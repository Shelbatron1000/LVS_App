﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ParentPortalWebView : ContentPage
	{
        private static string currentUrl = "https://lee.focusschoolsoftware.com/focus/";

        public ParentPortalWebView()
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