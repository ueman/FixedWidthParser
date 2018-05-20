using System;

namespace FixedWidthParser.Converters
{
    public class DoubleConverter : IFixedWidthConverter<double>
    {
        public bool CanConvertFrom => true;
        public bool CanConvertTo => true;
        
        public double From(string input)
        {
            return double.Parse(input);
        }

        public string To(double output, int width)
        {
            return output.ToString();
        }
    }
}