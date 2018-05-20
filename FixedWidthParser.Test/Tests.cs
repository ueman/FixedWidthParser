using System;
using FixedWidthParser.Attributes;
using FixedWidthParser.Test.TestClasses;
using NUnit.Framework;

namespace FixedWidthParser.Test
{
    [TestFixture]
    public class Tests
    {
        public static string[] test = new string[]
        {
            "123456734.6",
            "76543210.23",
            " b123cd0.34"
        };
        
        
        [Test]
        public void Test1()
        {
            var list = SimpleFixedWidthParser.ParseStringArray<TestClass>(test);
            Assert.True(list.Count == 3);
        }
    }
}