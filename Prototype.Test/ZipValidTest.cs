using Xunit;
using Prototype.Apply;
using Xamarin.Forms;

namespace Prototype.Test
{
    public class ZipValidTest
    {
        InputValidation valid;
        Entry testEntry;

        public ZipValidTest()
        {
            valid = new InputValidation();
            testEntry = new Entry();
        }

        [Fact]
        public void TestZip_WithLessDigits()
        {
            testEntry.Text = "1234"; //only 4 digits
            Assert.False(valid.ValidZip(testEntry));
        }

        [Fact]
        public void TestZip_WithAlpha()
        {
            testEntry.Text = "1234F"; //5 digits, with F as fifth
            Assert.False(valid.ValidZip(testEntry));
        }

        [Fact]
        public void TestZip_WithValid()
        {
            testEntry.Text = "12345"; //valid 5 numeric digits
            Assert.True(valid.ValidZip(testEntry));
        }
    }
}
