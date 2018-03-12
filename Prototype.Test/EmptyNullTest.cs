using Xunit;
using Prototype.Apply;
using Xamarin.Forms;


namespace Prototype.Test
{
    public class EmptyNullTest
    {
        InputValidation valid;
        Entry testEntry;
        Picker testPicker;

        public EmptyNullTest()
        {
            valid = new InputValidation();
            testEntry = new Entry();
            testPicker = new Picker();
        }

        [Fact]
        public void TestEmptyOrNull_WithNull()
        {
            Assert.True(valid.EmptyorNull(testEntry));
            testPicker.SelectedItem = null;
            Assert.True(valid.EmptyorNull(testPicker));
        }

        [Fact]
        public void TestEmptyOrNull_WithEmpty()
        {
            testEntry.Text = "";
            Assert.True(valid.EmptyorNull(testEntry));
        }
        [Fact]
        public void TestEmptyOrNull_WithFilled()
        {
            testEntry.Text = "TestText";
            Assert.False(valid.EmptyorNull(testEntry));
        }
    }
}
