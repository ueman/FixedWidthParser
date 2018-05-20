using System;
using System.Linq.Expressions;
using System.Reflection;
using FixedWidthParser.Attributes;
using FixedWidthParser.Extensions;
using NUnit.Framework;

namespace FixedWidthParser.Test.Extensions
{
    [TestFixture]
    public class PropertyInfoExtensionsTest
    {
        [Test]
        public void TestProperyInfo()
        {
            PropertyInfo result = typeof(TestClass).GetProperty(nameof(TestClass.TestProperty));
            var attribute = result.GetFixedWidthAttribute();
            Assert.IsTrue(attribute.GetType() == typeof(FixedWidthRangeAttribute));
        }
    }

    public class TestClass
    {
        [Obsolete]
        [FixedWidthRange(2,2)]
        public int TestProperty { get; set; }
        public int TestProperty1 { get; set; }
        public int TestProperty2 { get; set; }
        
    }
}