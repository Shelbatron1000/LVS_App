using Xamarin.Forms;
// <copyright file="InputValidationTest.cs">Copyright ©  2014</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Prototype.Apply;

namespace Prototype.Apply.Tests
{
    [TestFixture]
    [PexClass(typeof(InputValidation))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class InputValidationTest
    {

        [PexMethod]
        [PexAllowedException(typeof(NullReferenceException))]
        public bool EmptyorNull([PexAssumeUnderTest]InputValidation target, Entry entry)
        {
            bool result = target.EmptyorNull(entry);
            return result;
            // TODO: add assertions to method InputValidationTest.EmptyorNull(InputValidation, Entry)
        }
    }
}
