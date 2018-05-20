using FixedWidthParser.Attributes;

namespace FixedWidthParser.Test.TestClasses
{
    public class TestClass
    {
        [FixedWidthRange(0, 2)]
        public string One { get; set; }
        
        [FixedWidthRange(2, 3)]
        public int Two { get; set; }
        
        [FixedWidthRange(5, 2)]
        public string Three { get; set; }
        
        [FixedWidthRange(7, 4)]
        public double Four { get; set; }
    }
}