using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Prototype.Teachers;

namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElementaryPage : ContentPage
    {
        TeacherInfo data = new TeacherInfo();
        ObservableCollection<TeacherInfo.Teacher> allTeachers = new ObservableCollection<TeacherInfo.Teacher>();


        public ElementaryPage()
        {
            InitializeComponent();
            PopListView();
        }

        void PopListView()
        {

            foreach (TeacherInfo.Teacher teacher in data.elemTeachData)
            {
                allTeachers.Add(teacher);
            }

            listView.ItemsSource = allTeachers;

        }

        void DisableListView()
        {
            listView.IsEnabled = false;
            listView.FadeTo(0, 350, null);
            TitleLabel.FadeTo(0, 350, null);
            MainLayout.Children.Remove(listView);
            MainLayout.Children.Remove(TitleLabel);
        }
        void EnableListView()
        {
            listView.IsEnabled = true;
            listView.SelectedItem = null;
            listView.FadeTo(1, 350, null);
            TitleLabel.FadeTo(1, 350, null);
            MainLayout.Children.Add(TitleLabel);
            MainLayout.Children.Add(listView);
        }

        void BuildMoreInfo(TeacherInfo.Teacher selectedTeacher)
        {
            var layout = new StackLayout();
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            layout.Opacity = 0;
            layout.FadeTo(1, 350, null);
            Label teachName = new Label
            {
                Text = selectedTeacher.Name,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center

            };
            layout.Children.Add(teachName);
            Label teachPhone = new Label
            {
                Text = selectedTeacher.Phone,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            layout.Children.Add(teachPhone);
            Label teachEmail = new Label
            {
                Text = selectedTeacher.Email,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            layout.Children.Add(teachEmail);
            Label teachHours = new Label
            {
                Text = "Office Hours\n" + selectedTeacher.OfficeHours,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            layout.Children.Add(teachHours);

            Button apButton = new Button
           {
               Text = "Make An Appointment",
               HorizontalOptions = LayoutOptions.Center,
           };
            layout.Children.Add(apButton);
            apButton.Clicked += (send, ea) =>
            {
                Device.OpenUri(new Uri("http://www.genbook.com/bookings/slot/reservation/30106867?bookingContactId=1467440943&category=443131274"));
            };

            Button backButton = new Button
            {
                Text = "Back",
                HorizontalOptions = LayoutOptions.Center
            };
            layout.Children.Add(backButton);
            backButton.Clicked += (send, ea) =>
            {
                MainLayout.Children.Remove(layout);
                EnableListView();
                listView.SelectedItem = null;
            };
            MainLayout.Children.Add(layout);
        }

        void onSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            //Getting the teacher object from list
            var selectedTeacher = (TeacherInfo.Teacher)e.SelectedItem;
            DisableListView();
            BuildMoreInfo(selectedTeacher);



        }



    }
}