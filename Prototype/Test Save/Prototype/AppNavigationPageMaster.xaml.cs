using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ListView ListView;

        public AppNavigationPageMaster()
        {
            InitializeComponent();

            BindingContext = new AppNavigationPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        public class AppNavigationPageMasterViewModel: INotifyPropertyChanged
        {
            public ObservableCollection<MenuItem> MenuItems { get; set; }
            public static MenuItem _oldMenuItem = null;

            public AppNavigationPageMasterViewModel() 
            {
                MenuItems = new ObservableCollection<MenuItem>
                {
                    new MenuItem {
                        Id = 0,
                        Title = "Daily Login",
                    },
                    new MenuItem {
                        Id = 1,
                        Title = "Calendar",
                        TargetType = typeof(CalendarPage),
                    },
                    new MenuItem {
                        Id = 2,
                        Title = "Teachers",
                        TargetType = typeof(ContactsPage),
                        DoesExpand = true, //this has more levels!
                    },
                    new MenuItem {
                        Id = 3,
                        Title = "Elementary",
                        TargetType = typeof(ResourcesPage),
                        IsVisible = false,
                        parentId = 2,
                    },
                    new MenuItem {
                        Id = 4,
                        Title = "Secondary",
                        TargetType = typeof(ResourcesPage),
                        IsVisible = false,
                        parentId = 2,
                    },
                    new MenuItem {
                        Id = 5,
                        Title = "Resources",
                        TargetType = typeof(ResourcesPage),
                        IsVisible = true,
                        DoesExpand = true, //this has more levels!
                    },
                    new MenuItem {
                        Id = 6,
                        Title = "Apply",
                        TargetType = typeof(ApplyPage),
                    },
                };
            }


            internal void HideOrShowProduct(MenuItem m)
            {
                if (_oldMenuItem == m)
                {
                    // click twice on the same item will hide Submenus
                    m.IsVisible = !m.IsVisible;
                    m.OnPropertyChanged("IsVisible");
                }
                else
                {
                    if (_oldMenuItem != null)
                    {
                        // hide previous selected submenus
                        _oldMenuItem.IsVisible = false;
                        _oldMenuItem.OnPropertyChanged("IsVisible");
                    }
                    else
                    {

                        // show selected submenus
                        foreach (MenuItem sub in MenuItems)
                        {
                            if (sub.parentId == m.Id)
                            {
                                sub.IsVisible = true;
                                sub.OnPropertyChanged("IsVisible");
                            }
                        }
                    }
                }

                _oldMenuItem = m;
            }

            public event PropertyChangedEventHandler PropertyChanged;

            // This method is called by the Set accessor of each property.
            // The CallerMemberName attribute that is applied to the optional propertyName
            // parameter causes the property name of the caller to be substituted as an argument.
            public void OnPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }

            }
        }
    }
}