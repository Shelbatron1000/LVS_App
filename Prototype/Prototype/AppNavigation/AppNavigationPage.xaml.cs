using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppNavigationPage : MasterDetailPage
    {
        public AppNavigationPage()
        {
            InitializeComponent();

        }



        void ToHomePage()
        {
            var page = (Page)Activator.CreateInstance(typeof(HomePage));
            Detail = new NavigationPage(page);
            IsPresented = false;

        }

    }
}