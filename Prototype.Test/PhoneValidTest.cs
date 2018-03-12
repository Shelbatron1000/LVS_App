using Xunit;
using Prototype.Apply;
using Xamarin.Forms;

namespace Prototype.Test
{
    public class PhoneValidTest
    {
        InputValidation valid;
        Entry testEntry;

        public PhoneValidTest()
        {
            valid = new InputValidation();
            testEntry = new Entry();
        }

        [Fact]
        public void TestPhone_WithLessDigits()
        {
            testEntry.Text = "123456789"; //only 9 digits
            Assert.False(valid.ValidPhone(testEntry));
        }

        [Fact]
        public void TestPhone_WithAlpha()
        {
            testEntry.Text = "123456789F"; //10 digits, with F as tenth
            Assert.False(valid.ValidPhone(testEntry));
        }

        [Fact]
        public void TestPhone_WithValid()
        {
            testEntry.Text = "1234567890"; //valid 10 numeric digits
            Assert.True(valid.ValidPhone(testEntry));
        }
    }
}
