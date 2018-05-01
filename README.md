# LVS_App
Lee Virtual School, Fort Myers, Florida

The purpose of this project will be to develop a cross platform mobile application using Xamarin.Forms for Lee Virtual School (LVS). The mobile app will act as a hub for all things LVS. The goal is to have a centralized location for information and resources. The project will be developed for both iOS and Android mobile platforms. Users on these platforms will utilize the app to apply to be a student of LVS, track their attendance, view a calendar of events and more. While using secure protocols this app will communicate with databases hosted by LVS to allow in app functionality as opposed to just a shell of a mobile web page. The goal of this project is to create a mobile app that teachers and students alike will gladly utilize.


After cloning or downloading the repository, make sure to add the needed Google API code before deployment. The API Keys and other necessary information is unique to each Calendar and Sheet. The following needs to be edited before deployment:

CalendarPage.xaml.cs - line 12

Calendar myCalendar = new Calendar("API_KEY_HERE", "APP_NAME_HERE", "CALENDAR_ID_HERE");

TeacherInfo.cs - line 58 and 59

ApiKey = "API_KEY_HERE", ApplicationName = "APP_NAME_HERE"

TeacherInfo.cs - line 61

string spreadSheetID = "SPREADSHEET_ID_HERE";

Step4.xaml.CS line 21 and 22

string address = "ADDRESS_HERE"; string key = "KEY_HERE";
