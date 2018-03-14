using NUnit.Framework;
using Xamarin.Forms;

namespace UnitTests
{

    [TestFixture]
    public class GetTeacherDataTest
    {
        Prototype.TeacherInfo data;

        public GetTeacherDataTest()
        {
            
        }

        [Test]
        public void GetTeacherData_ExceptionsTest()
        {
            //test fails if exception is thrown
            Assert.DoesNotThrow(() => { data = new Prototype.TeacherInfo(); }); 
        }
    }
}
