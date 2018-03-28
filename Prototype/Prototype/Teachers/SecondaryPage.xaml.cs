using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondaryPage : ContentPage
    {
        TeacherInfo data;
        ObservableCollection<TeacherInfo.Teacher> allTeachers = new ObservableCollection<TeacherInfo.Teacher>();

        public SecondaryPage()
        {
            InitializeComponent();
            Task.Run(() =>
            {
                data = new TeacherInfo();
                Device.BeginInvokeOnMainThread(() =>
                {

                    PopListView();
                });

            });
        }

        void PopListView()
        {

            foreach (TeacherInfo.Teacher teacher in data.secTeachData)
            {
                allTeachers.Add(teacher);
            }

            listView.ItemsSource = allTeachers;

        }

        void LoadMoreInfo(TeacherInfo.Teacher teacher)
        {
            //Push the next page, Step2, onto the Nav stack, pass it the Application object that was created here.
            Teachers.MoreInfoPage newPage = new Teachers.MoreInfoPage(teacher);
            Navigation.PushAsync(newPage);
        }

        void onSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            //Getting the teacher object from list
            var selectedTeacher = (TeacherInfo.Teacher)e.SelectedItem;
            LoadMoreInfo(selectedTeacher);
            listView.SelectedItem = null; //clearing the selection from the listview
        }
      
    }
}