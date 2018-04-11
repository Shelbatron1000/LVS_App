using System;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using System.Numerics;
namespace Prototype.Apply
{
    public class InputValidation
    {


        //Check to see if an entry field is empty or null
        public bool EmptyorNull(Entry entry)
        {
            if (string.IsNullOrEmpty(entry.Text))
            {
                //before returning, make it obvious on the GUI where the empty or null field is located.
                entry.BackgroundColor = Color.Red;
                entry.PlaceholderColor = Color.White;
                entry.TextColor = Color.White;
                return true;
            }
            entry.BackgroundColor = Color.White;
            entry.PlaceholderColor = Color.Blue;
            entry.TextColor = Color.Black;

            return false;
        }

        //Check to see if a picker is null
        public bool EmptyorNull(Picker picker)
        {
            if (picker.SelectedItem == null)
            {
                picker.BackgroundColor = Color.Red;
                picker.TextColor = Color.White;
                return true;
            }
            picker.BackgroundColor = Color.White;
            picker.TextColor = Color.Black;
            return false;
        }

        //check to see if the email entry field is a valid email address
        public bool ValidEmail(Entry entry)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if(regex.IsMatch(entry.Text))
            {
                entry.BackgroundColor = Color.White;
                entry.TextColor = Color.Black;

                return true; //it is a correct email pattern
            }
            entry.BackgroundColor = Color.Red;
            entry.TextColor = Color.White;

            return false;
        }

        //check to see if a phone number is in a valid format
        public bool ValidPhone(Entry entry)
        {
            if(entry.Text.Length ==10) //ten digit phone number
            {
                Char[] arr = entry.Text.ToCharArray();
                foreach(Char digit in arr)
                {
                    if(!Char.IsNumber(digit)){
                        entry.BackgroundColor = Color.Red;
                        entry.TextColor = Color.White;
                        return false;
                    }
                }
                entry.BackgroundColor = Color.White;
                entry.TextColor = Color.Black;
                return true;
            }
            entry.BackgroundColor = Color.Red;
            entry.TextColor = Color.White;
            return false;
        }

        //check to see if a phone number is in a valid format
        public bool ValidZip(Entry entry)
        {
            if (entry.Text.Length == 5) //5 digit zip code
            {
                Char[] arr = entry.Text.ToCharArray();
                foreach (Char digit in arr)
                {
                    if (!Char.IsNumber(digit))
                    {
                        entry.BackgroundColor = Color.Red;
                        entry.TextColor = Color.White;
                        return false;
                    }
                }
                entry.BackgroundColor = Color.White;
                entry.TextColor = Color.Black;
                return true;
            }
            entry.BackgroundColor = Color.Red;
            entry.TextColor = Color.White;
            return false;
        }

        //check to see if a date is valid
        //will receive mm/dd/yyyy if valid
        public bool ValidDate(Entry entry)
        {
            var parts = entry.Text.Split('/');
            if(!ValidDobYear(int.Parse(parts[2])) || //if invalid year
               !ValidDobDay(int.Parse(parts[1])) ||  //if invalid day
               !ValidDobMonth(int.Parse(parts[0])))  //if invalid month
            {
                entry.BackgroundColor = Color.Red;
                entry.TextColor = Color.White;
                return false;
            }


            entry.BackgroundColor = Color.White;
            entry.TextColor = Color.Black;
            return true;
        }

        //check to see if a date is 8 digits long mmddyyyy
        public bool EightDigitDate(Entry entry)
        {
            if (entry.Text.Length == 8) //8 digit date mmddyyyy
            {
                Char[] arr = entry.Text.ToCharArray();
                foreach (Char digit in arr)
                {
                    if (!Char.IsNumber(digit))
                    {
                        entry.BackgroundColor = Color.Red;
                        entry.TextColor = Color.White;
                        return false;
                    }
                }
                entry.BackgroundColor = Color.White;
                entry.TextColor = Color.Black;
                return true;
            }
            entry.BackgroundColor = Color.Red;
            entry.TextColor = Color.White;
            return false;
        }

        //this method will check for extreme values of year. highest 2025 lowest 1950
        public bool ValidDobYear(int year)
        {
            if(year >=2025 || year <=1950)
            {
                return false;
            }
            return true;
        }

        public bool ValidDobDay(int day)
        {
            if(day <=0 || day >31)
            {
                return false;
            }
            return true;
        }

        public bool ValidDobMonth(int month)
        {
            if(month <=0 || month >12)
            {
                return false;
            }
            return true;
        }


    }
}
