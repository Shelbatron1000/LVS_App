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
    public partial class AppNavigationPage : MasterDetailPage
    {
        public AppNavigationPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuItem;
            if (item == null)
                return;

            if (item.DoesExpand == false)
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title;

                Detail = new NavigationPage(page);
                IsPresented = false;
            }
            else
            { 
                //var vm = new AppNavigationPageMaster.AppNavigationPageMasterViewModel();
                //vm?.HideOrShowProduct(item);
            }

            MasterPage.ListView.SelectedItem = null;

        }

        void ToHomePage()
        {
            var page = (Page)Activator.CreateInstance(typeof(HomePage));
            //page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }



    }
}