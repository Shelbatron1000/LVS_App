using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics.Contracts;
using System.Reflection;
using Xamarin.Forms.Internals;


namespace Prototype{
    public class TeacherInfo
    {
        public List<Teacher> elemTeachData = new List<Teacher>();
        public List<Teacher> secTeachData = new List<Teacher>();

        public TeacherInfo()
        {
            GetTeacherData();
        }

    private void GetTeacherData()
        {
            try
            {
                var assembly = typeof(TeacherInfo).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("Prototype.Teachers.ElementaryTeachers.csv");
                using (var reader = new StreamReader(stream))
                {
                    string text;
                    while ((text = reader.ReadLine()) != null)
                    {
                        ParseTeachers(text);
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }



        }

        // The following method will take a string and parse it and create a
        //teacher object. It will then add the object to its respective list.
        private void ParseTeachers(string line)
        {
            Char delim = ',';
            String[] info = line.Split(delim);
            Teacher temp = new Teacher(info[0], info[1], info[2], info[3], info[4]);
            if (temp.School.Equals("Elementary"))
            {
                elemTeachData.Add(temp);
            }
            else if (temp.School.Equals("Secondary"))
            {
                secTeachData.Add(temp);
            }
        }

        //the following method will search a list of teachers via the name 
        // and return true if it exists.
        public Teacher SearchList(string name, string phone, List<Teacher> list)
        {
            Teacher temp = new Teacher();
            foreach (Teacher teacher in list)
            {
                if (teacher.Name.Equals(name) && teacher.Phone.Equals(phone))
                {
                    temp = teacher;
                }
            }
            return temp;
        }

        public bool TeacherExists(string name, string phone, List<Teacher> list)
        {
            foreach (Teacher teacher in list)
            {
                if (teacher.Name.Equals(name) && teacher.Phone.Equals(phone))
                {
                    return true;
                }
            }
            return false;
        }


        public struct Teacher
        {
            public string School { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string OfficeHours { get; set; }

            public Teacher(string school, string name, string email, string phone, string officeHours)
            {
                this.Name = name;
                this.School = school;
                this.Phone = phone;
                this.Email = email;
                this.OfficeHours = officeHours;
            }

        }

    }

}

