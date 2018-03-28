using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace Prototype.Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarList : ContentPage
    {
        Calendar myCalendar = new Calendar("AIzaSyCUveAaJAyfqBoQUA0Z7iJXg4xQb8DHCG8", "LVIP-App", "shelbatron1000@gmail.com");     
        public CalendarList()
        {
            InitializeComponent();

            Task.Run(() =>
            {
                myCalendar.GetEvents();
                Device.BeginInvokeOnMainThread(() =>
                {
                   
                    MyListView.ItemsSource = myCalendar.Events;
                    spinner.IsVisible = false;
                    spinner.IsRunning = false;
                });

            });

        }



        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

    }
}
