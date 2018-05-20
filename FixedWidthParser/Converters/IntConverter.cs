using System;

namespace FixedWidthParser.Converters
{
    public class IntConverter : IFixedWidthConverter<int>
    {    
        public int From(string input)
        {
            return Convert.ToInt32(input);
        }

        public string To(int output, int width)
        {
            return output.ToString().PadRight(width);
        }

        public bool CanConvertFrom => true;
        public bool CanConvertTo => true;
    }
}