using FixedWidthParser.Attributes;
using FixedWidthParser;
using FixedWidthParser.Converters;

namespace ConsoleTest
{
    internal class Program
    {
        public static string[] test = new string[]
        {
            "123456734,6",
            "76543210.23",
            "ab123cd0,34"
        };
        
        
        public static void Main(string[] args)
        {
            var list = SimpleFixedWidthParser.ParseStringArray<TestClass>(test);
            
        }
    }
    
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