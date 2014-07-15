using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Core.Validation;
using System.ComponentModel.DataAnnotations;

namespace Shared.Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new TestClass();
            
            var d = (IValidatableObject)c;
        }

        
    }

    class TestClass : ValidatableObjectBase
    {
    }
}
