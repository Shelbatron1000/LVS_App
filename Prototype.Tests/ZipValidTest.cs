using NUnit.Framework;
using Xamarin.Forms;

namespace UnitTests
{

    [TestFixture]
    public class ZipValidTest
    {
        Prototype.Apply.InputValidation valid;
        Entry testEntry;

        public ZipValidTest()
        {
            valid = new Prototype.Apply.InputValidation();
            testEntry = new Entry();
        }

        
        [Test]
        public void TestZip_WithLessDigits()
        {
            testEntry.Text = "1234"; //only 4 digits
            Assert.IsFalse(valid.ValidZip(testEntry));
        }

        [Test]
        public void TestZip_WithAlpha()
        {
            testEntry.Text = "1234F"; //5 digits, with F as fifth
            Assert.IsFalse(valid.ValidZip(testEntry));
        }

        [Test]
        public void TestZip_WithValid()
        {
            testEntry.Text = "12345"; //valid 5 numeric digits
            Assert.IsTrue(valid.ValidZip(testEntry));
        }
    }
}
