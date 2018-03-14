using NUnit.Framework;
using Xamarin.Forms;

namespace UnitTests
{
    [TestFixture]
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

        [Test]
        public void TestEmptyOrNull_WithNull()
        {
            Assert.IsTrue(valid.EmptyorNull(testEntry));
            testPicker.SelectedItem = null;
            Assert.IsTrue(valid.EmptyorNull(testPicker));
        }

        [Test]
        public void TestEmptyOrNull_WithEmpty()
        {
            testEntry.Text = "";
            Assert.IsTrue(valid.EmptyorNull(testEntry));
        }

        [Test]
        public void TestEmptyOrNull_WithFilled()
        {
            testEntry.Text = "TestText";
            Assert.IsFalse(valid.EmptyorNull(testEntry));
        }
    }
}
