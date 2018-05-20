using System;
using FixedWidthParser.Converters;

namespace FixedWidthParser.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FixedWidthRangeAttribute : Attribute
    {
        public int From { get; set; }
        public int Length { get; set; }
        public Type Converter { get; set; }

        public FixedWidthRangeAttribute(int from, int length)
        {
            From = from;
            Length = length;
        }
        
        public FixedWidthRangeAttribute(int from, int length, Type converter)
        {
            From = from;
            Length = length;
            Converter = converter;
            if (typeof(IFixedWidthConverter<>).IsAssignableFrom(Converter))
            {
                
            }
        }
    }
}