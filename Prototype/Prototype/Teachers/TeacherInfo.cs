using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

using System.Diagnostics;


namespace Prototype
{
    public class TeacherInfo
    {
        public List<Teacher> elemTeachData = new List<Teacher>();
        public List<Teacher> secTeachData = new List<Teacher>();

        public TeacherInfo()
        {
            GetDataFromDrive();
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

        //////////////GOOGLE SHEETS API CODE////

        //The following method connects to the GoogkeSheet on Google Drive
        public void GetDataFromDrive()
        {
            var service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAaHEj4BFh8CxmczhLokH4QDsRYa1smV5g",
                ApplicationName = "lee-virtual-mobile"

            });
            string spreadSheetID = "1XCayVZlGxZp7rnQ0k3cZ1JkTmXltTQc1t-9rggR_A08";
            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(spreadSheetID, "Sheet1!A2:F");
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values !=null && values.Count >0)
            {
                foreach (var row in values)
                {
                    Teacher temp = new Teacher();
                    bool minIsFilled = false;

                    //check that minimum fields are filled out
                    if(row.Count >= 4)
                    {
                        if(row[0].ToString() != "" && row[1].ToString() != "" && row[2].ToString() != "" && row[3].ToString() != "")
                        {
                            minIsFilled = true;
                        }
                    }

                    if (minIsFilled) // if minimum fields are filled out, proceed with adding to collections
                    {
                        if (row.Count == 5) //minimum fields filled out
                        {
                            temp = new Teacher(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), "");

                        }
                        else if (row.Count == 6) //all fields filled out
                        {
                            temp = new Teacher(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                        }

                        //If the Elementary or Secondary is not defined in the Google Sheet, the Teacher object will NOT be added to either collection
                        if (temp.School.Equals("Elementary"))
                        {
                            elemTeachData.Add(temp);
                        }
                        else if (temp.School.Equals("Secondary"))
                        {
                            secTeachData.Add(temp);
                        }
                    } //end minIsField if
                }
            }
        }

        public struct Teacher
        {
            public string School { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string OfficeHours { get; set; }
            public string Notes { get; set; }

            public Teacher(string school, string name, string email, string phone, string officeHours, string notes)
            {
                this.Name = name;
                this.School = school;
                this.Phone = phone;
                this.Email = email;
                this.OfficeHours = officeHours;
                this.Notes = notes;
            }

        }

    }

}

