using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppNavigationPageMaster : ContentPage
    {
        public StackLayout subMenu_old;

        public AppNavigationPageMaster()
        {
            InitializeComponent();
        }

        public void Navigate(Type p)
        {
            //How to switch to page
            var page = (ContentPage)Activator.CreateInstance(p);
            App app = Application.Current as App;
            MasterDetailPage md = (MasterDetailPage)app.MainPage;
            md.Detail = new NavigationPage(page);
            md.IsPresented = false;
        }

        public void DailyLoginClicked(object sender, EventArgs e)
        {
            //Implement WebView here
        }

        public void CalendarClicked(object sender, EventArgs e)
        {
            Navigate(typeof(CalendarPage));
        }

        public void TeachersClicked(object sender, EventArgs e)
        {
            //Show or Hide SubMenu
            HideOrShowSubMenu(TeacherSubMenuItems);
        }

        public void ElementaryClicked(object sender, EventArgs e)
        {
            Navigate(typeof(ElementaryPage));
        }

        public void SecondaryClicked(object sender, EventArgs e)
        {
            Navigate(typeof(SecondaryPage));
        }

        public void ResourcesClicked(object sender, EventArgs e)
        {
            Navigate(typeof(ResourcesPage));
        }

        public void ApplyClicked(object sender, EventArgs e)
        {
            Navigate(typeof(ApplyPage));
        }

        internal void HideOrShowSubMenu(StackLayout subMenu)
        {
            if (subMenu_old == null)
            {
                subMenu.IsVisible = true;
            }
            else if (subMenu_old.Id == subMenu.Id)
            {
                // click twice on the same item will hide Submenus
                subMenu.IsVisible = !subMenu.IsVisible;
            }
            else
            {
                    // hide previous selected submenus
                    subMenu_old.IsVisible = false;
                    subMenu.IsVisible = true;
            }

            subMenu_old = subMenu;
        }
    }
}