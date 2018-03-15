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
            //Reset Boldness of last selected menu item
            if (AppNavigationPageMaster.selected == null)
            {
                //do nothing
            }
            else
            {
                // make previous not bold
                AppNavigationPageMaster.selected.FontAttributes = FontAttributes.None;
                
            }

            var page = (Page)Activator.CreateInstance(typeof(HomePage));
            var whiteNav = new NavigationPage(page)
            {
                BarTextColor = Color.White
            };
            Detail = whiteNav;
            IsPresented = false;
        }

    }
}