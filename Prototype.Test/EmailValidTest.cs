using Xunit;
using Prototype.Apply;
using Xamarin.Forms;

namespace Prototype.Test
{
    public class EmailValidTest
    {
        InputValidation valid;
        Entry testEntry;

        public EmailValidTest()
        {
            valid = new InputValidation();
            testEntry = new Entry();
        }

        [Fact]
        public void TestEmail_WithWrongStart()
        {
            testEntry.Text = "@email.com";
            Assert.False(valid.ValidEmail(testEntry));
        }

        [Fact]
        public void TestEmail_WithWrongEnding()
        {
            testEntry.Text = "test@email";
            Assert.False(valid.ValidEmail(testEntry));
        }

        [Fact]
        public void TestEmail_WithNoAt()
        {
            testEntry.Text = "testemail.com";
            Assert.False(valid.ValidEmail(testEntry));
        }

        [Fact]
        public void TestEmail_WithValid()
        {
            testEntry.Text = "test@email.com";
            Assert.True(valid.ValidEmail(testEntry));
        }

    }
}
