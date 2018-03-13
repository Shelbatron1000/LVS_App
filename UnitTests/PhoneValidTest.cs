using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;

namespace UnitTests
{

    [TestClass]
    public class PhoneValidTest
    {
        Prototype.Apply.InputValidation valid;
        Entry testEntry;

        public PhoneValidTest()
        {
            valid = new Prototype.Apply.InputValidation();
            testEntry = new Entry();
        }

        [TestMethod]
        public void TestPhone_WithLessDigits()
        {
            testEntry.Text = "123456789"; //only 9 digits
            Assert.IsFalse(valid.ValidPhone(testEntry));
        }

        [TestMethod]
        public void TestPhone_WithAlpha()
        {
            testEntry.Text = "123456789F"; //10 digits, with F as tenth
            Assert.IsFalse(valid.ValidPhone(testEntry));
        }

        [TestMethod]
        public void TestPhone_WithValid()
        {
            testEntry.Text = "1234567890"; //valid 10 numeric digits
            Assert.IsTrue(valid.ValidPhone(testEntry));
        }
    }
}
