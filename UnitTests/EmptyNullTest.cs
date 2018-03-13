using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype;
using Xamarin.Forms;

namespace UnitTests
{
    [TestClass]
    public class EmptyNullTest
    {
        Prototype.Apply.InputValidation valid;
        Entry testEntry;
        Picker testPicker;

        public EmptyNullTest()
        {
            valid = new Prototype.Apply.InputValidation();
            testEntry = new Entry();
            testPicker = new Picker();
        }

        [TestMethod]
        public void TestEmptyOrNull_WithNull()
        {
            Assert.IsTrue(valid.EmptyorNull(testEntry));
            testPicker.SelectedItem = null;
            Assert.IsTrue(valid.EmptyorNull(testPicker));
        }

        [TestMethod]
        public void TestEmptyOrNull_WithEmpty()
        {
            testEntry.Text = "";
            Assert.IsTrue(valid.EmptyorNull(testEntry));
        }

        [TestMethod]
        public void TestEmptyOrNull_WithFilled()
        {
            testEntry.Text = "TestText";
            Assert.IsFalse(valid.EmptyorNull(testEntry));
        }
    }
}
