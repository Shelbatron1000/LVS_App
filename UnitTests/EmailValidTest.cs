using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using Prototype;

namespace UnitTests
{

    [TestClass]
    public class EmailValidTest
    {
        Prototype.Apply.InputValidation valid;
        Entry testEntry;
        public EmailValidTest()
        {
            valid = new Prototype.Apply.InputValidation();
            testEntry = new Entry();
        }

        [TestMethod]
        public void TestEmail_WithWrongStart()
        {
            testEntry.Text = "@email.com";
            Assert.IsFalse(valid.ValidEmail(testEntry));
        }


        [TestMethod]
        public void TestEmail_WithWrongEnding()
        {
            testEntry.Text = "test@email";
            Assert.IsFalse(valid.ValidEmail(testEntry));
        }

        [TestMethod]
        public void TestEmail_WithNoAt()
        {
            testEntry.Text = "testemail.com";
            Assert.IsFalse(valid.ValidEmail(testEntry));
        }

        [TestMethod]
        public void TestEmail_WithValid()
        {
            testEntry.Text = "test@email.com";
            Assert.IsTrue(valid.ValidEmail(testEntry));
        }
    }
}
