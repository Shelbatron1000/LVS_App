using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{

    public class MenuItem : INotifyPropertyChanged
    {
        public MenuItem()
        {
            TargetType = typeof(HomePage);
            parentId = 0; //0 means it is a main level menuitem
            DoesExpand = false;
            IsVisible = true;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public bool DoesExpand { get; set; }

        public bool IsVisible { get; set; }

        public Type TargetType { get; set; }

        public int parentId { get; set; }

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