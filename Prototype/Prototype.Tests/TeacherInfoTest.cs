using System.Reflection;
// <copyright file="TeacherInfoTest.cs">Copyright ©  2014</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Prototype;

namespace Prototype.Tests
{
    /// <summary>This class contains parameterized unit tests for TeacherInfo</summary>
    [PexClass(typeof(TeacherInfo))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class TeacherInfoTest
    {

        [PexMethod]
        [PexMethodUnderTest("GetTeacherData()")]
        internal void GetTeacherData([PexAssumeUnderTest]TeacherInfo target)
        {
            object[] args = new object[0];
            Type[] parameterTypes = new Type[0];
            object result = ((MethodBase)(typeof(TeacherInfo).GetMethod("GetTeacherData",
                                                                        BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic, (Binder)null,
                                                                        CallingConventions.HasThis, parameterTypes, (ParameterModifier[])null)))
                                .Invoke((object)target, args);
            // TODO: add assertions to method TeacherInfoTest.GetTeacherData(TeacherInfo)
        }
    }
}
