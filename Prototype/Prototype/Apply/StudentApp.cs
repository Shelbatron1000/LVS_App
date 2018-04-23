using System;
using System.Collections.ObjectModel;
namespace Prototype.Apply
{
    /* This class represents an entire application form that a student or guardian
     * would fill out in order to have themselves or their child become a student
     * at LVS. The team was given a sample application in PDF form and all of the 
     * information on that PDF was used to create this class.
     * The application is split up into four parts:
     * 1. Student - the individual applying to become a LVS student.
     * 2. SchoolInfo - Information about the last school that the individual
     *    attended as well as the grade for which they are applying to enter.
     * 3. Guardian - information for the parent or guardian of the student applying.
     * 4. EligibilityQuestions - These are answers to the additional questions 
     *    that were on the PDF application that we were provided.
     */

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
        public string enrollType { get; set; }
        public string studentID { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string dateOfBirth { get; set; }
        public string streetAddress { get; set; }
        public string unitNumber { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string phoneNumber { get; set; }
        public string phoneType { get; set; }
        public string studentEmail { get; set; } 
    }
    public class SchoolInfo
    {
        public string schoolName { get; set; }
        public string grade { get; set; }
        public string district { get; set; }
        public string county { get; set; }
        public string districtState { get; set; }
    }
    public class Guardian
    {
        public string guardianLastName { get; set; }
        public string guardianFirstName { get; set; }
        public string guardianPhoneNumber { get; set; }
        public string guardianPhoneType { get; set; }
        public string guardianEmailAddress { get; set; }
        public string relationship { get; set; }
    }
    public class EligibilityQuestions
    {
        public string eqResponse1 { get; set; }
        public string eqResponse2 { get; set; }
        public string eqResponse3 { get; set; }
        public string eqResponse4 { get; set; }
        public string eqResponse5 { get; set; }
        public string eqResponse6 { get; set; }
        public string eqResponse7 { get; set; }
        public string eqResponse8 { get; set; }

    }

}
