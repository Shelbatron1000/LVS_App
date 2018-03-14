using NUnit.Framework;
using Xamarin.Forms;

namespace UnitTests
{

    [TestFixture]
    public class EmailValidTest
    {
        Prototype.Apply.InputValidation valid;
        Entry testEntry;
        public EmailValidTest()
        {
            valid = new Prototype.Apply.InputValidation();
            testEntry = new Entry();
        }

        [Test]
        public void TestEmail_WithWrongStart()
        {
            testEntry.Text = "@email.com";
            Assert.IsFalse(valid.ValidEmail(testEntry));
        }


        [Test]
        public void TestEmail_WithWrongEnding()
        {
            testEntry.Text = "test@email";
            Assert.IsFalse(valid.ValidEmail(testEntry));
        }

        [Test]
        public void TestEmail_WithNoAt()
        {
            testEntry.Text = "testemail.com";
            Assert.IsFalse(valid.ValidEmail(testEntry));
        }

        [Test]
        public void TestEmail_WithValid()
        {
            testEntry.Text = "test@email.com";
            Assert.IsTrue(valid.ValidEmail(testEntry));
        }
    }
}
