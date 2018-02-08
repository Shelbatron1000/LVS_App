using Android.Content;
using Android.Telephony;
using Prototype.WebViews;
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
        public static Label selected;

        public AppNavigationPageMaster()
        {
            InitializeComponent();
        }

        //This method navigates to the page of type p
        public void Navigate(Type p)
        {
            //How to switch to page
            var page = (ContentPage)Activator.CreateInstance(p);
            App app = Application.Current as App;
            MasterDetailPage md = (MasterDetailPage)app.MainPage;
            var whiteNav = new NavigationPage(page)
            {
                BarTextColor = Color.White
            };

            md.Detail = whiteNav;
            md.IsPresented = false;
        }

        public void AttendanceClicked(object sender, EventArgs e)
        {
            Navigate(typeof(AttendanceWebView));
            BoldLabels(AttendanceLabel);
        }

        public void CalendarClicked(object sender, EventArgs e)
        {
            Navigate(typeof(CalendarPage));
            BoldLabels(CalendarLabel);
        }

        public void TeachersClicked(object sender, EventArgs e)
        {
            //Show or Hide SubMenu
            HideOrShowSubMenu(TeacherSubMenuItems);
        }

        public void ElementaryClicked(object sender, EventArgs e)
        {
            Navigate(typeof(ElementaryPage));
            BoldLabels(ElementaryLabel);
        }

        public void SecondaryClicked(object sender, EventArgs e)
        {
            Navigate(typeof(SecondaryPage));
            BoldLabels(SecondaryLabel);
        }

        public void AppointmentsClicked(object sender, EventArgs e)
        {
            Navigate(typeof(AppointmentsWebView));
            BoldLabels(AppointmentsLabel);
        }

        public void ResourcesClicked(object sender, EventArgs e)
        {
            Navigate(typeof(ResourcesPage));
            BoldLabels(ResourcesLabel);
        }

        public void ApplyClicked(object sender, EventArgs e)
        {
            Navigate(typeof(ApplyPage));
            BoldLabels(ApplyLabel);
        }

        public void ParentPortalClicked(object sender, EventArgs e)
        {
            //The FOCUS website does not render correctly for an in-app webview for Android but does so for iOS
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Navigate(typeof(ParentPortalWebView));
                    break;
                case Device.Android:
                    if (Device.Idiom == TargetIdiom.Phone)
                    {
                        System.Diagnostics.Debug.WriteLine("Mobile");
                        Device.OpenUri(new Uri("https://lee.focusschoolsoftware.com/focus/"));                 
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Tablet");
                        Navigate(typeof(ParentPortalWebView));
                    }                
                    break;
                default:
                    Device.OpenUri(new Uri("https://lee.focusschoolsoftware.com/focus/"));
                    break;
            }

            BoldLabels(ParentPortalLabel);
        }

        public void FLVSClicked(object sender, EventArgs e)
        {
            //FLVS does not have a mobile app yet... 
            Navigate(typeof(FLVSWebView));
            BoldLabels(FLVSLabel);
        }

        //this method hides or shows submenus
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

        //this method will bold the label the user selected and unbold the previous selected label
        internal void BoldLabels(Label justSelected)
        {
            if (selected == null)
            {
                justSelected.FontAttributes = FontAttributes.Bold;
            }
            else if (selected.Id == justSelected.Id)
            {
                //do nothing - keep it bold
            }
            else
            {
                // make previous not bold
                selected.FontAttributes = FontAttributes.None;
                justSelected.FontAttributes = FontAttributes.Bold;
            }

            selected = justSelected;
        }
    }
}