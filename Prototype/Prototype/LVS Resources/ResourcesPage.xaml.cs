﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResourcesPage : ContentPage
    {
        public ResourcesPage()
        {
            InitializeComponent();
        }

        public void ToLoginClicked(object sender, EventArgs e)
        {
            DailyLoginWebView newPage = new DailyLoginWebView();

            Navigation.PushAsync(newPage);
        }
    }
}