using System;
using System.Collections.ObjectModel;
namespace Prototype.Apply
{
    public class StudentApp
    {
        private Student Student { get; set; }
        private SchoolInfo LastSchool { get; set; }
        private Guardian Guardian { get; set; }
        private EligibilityQuestions Questions { get; set; }

        public StudentApp()
        {
        }

    }

    public class Student
    {
        private string EnrollType { get; set; }
        private string StudentID { get; set; }
        private string LastName { get; set; }
        private string FirstName { get; set; }
        private string DOB { get; set; }
        private string StreetAddress { get; set; }
        private string UnitNumber { get; set; }
        private string City { get; set; }
        private string ZipCode { get; set; }
        private string PhoneNumber { get; set; }
        private string PhoneType { get; set; }
        private string StudentEmail { get; set; } 
    }
    public class SchoolInfo
    {
        private string SchoolName { get; set; }
        private string Grade { get; set; }
        private string District { get; set; }
        private string County { get; set; }
        private string State { get; set; }
    }
    public class Guardian
    {
        private string LastName { get; set; }
        private string FirstName { get; set; }
        private string GuardianPhoneNumber { get; set; }
        private string GuardianPhoneType { get; set; }
        private string EmailAddress { get; set; }
        private string Relationship { get; set; }
    }
    public class EligibilityQuestions
    {
        private string EQResponse1 { get; set; }
        private string EQResponse2 { get; set; }
        private string EQResponse3 { get; set; }
        private string EQResponse4 { get; set; }
        private string EQResponse5 { get; set; }
        private string EQResponse6 { get; set; }
        private string EQResponse7 { get; set; }
        private string EQResponse8 { get; set; }

    }

}
