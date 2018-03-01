using System;
using System.Collections.ObjectModel;
namespace Prototype.Apply
{
    public class StudentApp
    {
        public Student Student { get; set; }
        public SchoolInfo LastSchool { get; set; }
        public Guardian Guardian { get; set; }
        public EligibilityQuestions Questions { get; set; }

        public StudentApp()
        {
        }

    }

    public class Student
    {
        public string EnrollType { get; set; }
        public string StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string DOB { get; set; }
        public string StreetAddress { get; set; }
        public string UnitNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
        public string StudentEmail { get; set; } 
    }
    public class SchoolInfo
    {
        public string SchoolName { get; set; }
        public string Grade { get; set; }
        public string District { get; set; }
        public string County { get; set; }
        public string State { get; set; }
    }
    public class Guardian
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string GuardianPhoneNumber { get; set; }
        public string GuardianPhoneType { get; set; }
        public string EmailAddress { get; set; }
        public string Relationship { get; set; }
    }
    public class EligibilityQuestions
    {
        public string EQResponse1 { get; set; }
        public string EQResponse2 { get; set; }
        public string EQResponse3 { get; set; }
        public string EQResponse4 { get; set; }
        public string EQResponse5 { get; set; }
        public string EQResponse6 { get; set; }
        public string EQResponse7 { get; set; }
        public string EQResponse8 { get; set; }

    }

}
