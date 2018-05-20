using FixedWidthParser.Converters;
using NUnit.Framework;

namespace FixedWidthParser.Test.Converters
{
    [TestFixture]
    public class IntConverterTest
    {
        [Test]
        public void TestConvertFrom([Values(1,2,3,4,5)] int output)
        {
            var converter = new IntConverter();
            Assert.True(output == converter.From(output.ToString()));
        }

        [Test]
        public void TestConvertTo(
        [Values(1,2,3,4,10,11,12,12,12)] int input,
        [Values(4, 5, 6)] int width
            )
        {
            var converter = new IntConverter();
            var output = converter.To(input, width);
            Assert.True(output.EndsWith(input.ToString()));
        }
        
    }
}