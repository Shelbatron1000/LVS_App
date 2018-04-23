using System;
namespace Prototype.Apply
{
    public class ApplicationForAPI
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
        public string schoolName { get; set; }
        public string grade { get; set; }
        public string district { get; set; }
        public string county { get; set; }
        public string districtState { get; set; }
        public string guardianLastName { get; set; }
        public string guardianFirstName { get; set; }
        public string guardianPhoneNumber { get; set; }
        public string guardianPhoneType { get; set; }
        public string guardianEmailAddress { get; set; }
        public string relationship { get; set; }
        public string eqResponse1 { get; set; }
        public string eqResponse2 { get; set; }
        public string eqResponse3 { get; set; }
        public string eqResponse4 { get; set; }
        public string eqResponse5 { get; set; }
        public string eqResponse6 { get; set; }
        public string eqResponse7 { get; set; }
        public string eqResponse8 { get; set; }


        public ApplicationForAPI(Student student, SchoolInfo info, Guardian guardian, EligibilityQuestions eq)
        {
            enrollType = student.enrollType;
            studentID = student.studentID;
            lastName = student.lastName;
            firstName = student.firstName;
            middleName = student.middleName;
            dateOfBirth = student.dateOfBirth;
            streetAddress = student.streetAddress;
            unitNumber = student.unitNumber;
            city = student.city;
            state = student.state;
            zipCode = student.zipCode;
            phoneNumber = student.phoneNumber;
            phoneType = student.phoneType;
            studentEmail = student.studentEmail;
            schoolName = info.schoolName;
            grade = info.grade;
            district = info.district;
            county = info.county;
            districtState = info.districtState;
            guardianLastName = guardian.guardianLastName;
            guardianFirstName = guardianFirstName;
            guardianPhoneNumber = guardian.guardianPhoneNumber;
            guardianPhoneType = guardian.guardianPhoneType;
            guardianEmailAddress = guardian.guardianEmailAddress;
            relationship = guardian.relationship;
            eqResponse1 = eq.eqResponse1;
            eqResponse2 = eq.eqResponse2;
            eqResponse3 = eq.eqResponse3;
            eqResponse4 = eq.eqResponse4;
            eqResponse5 = eq.eqResponse5;
            eqResponse6 = eq.eqResponse6;
            eqResponse7 = eq.eqResponse7;
            eqResponse8 = eq.eqResponse8;


        }
    }
}
