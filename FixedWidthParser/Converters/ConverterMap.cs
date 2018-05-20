using System;
using System.Collections.Generic;

namespace FixedWidthParser.Converters
{
    public static class ConverterMap
    {
        public static Dictionary<Type, IFixedWidthConverter> Converters = new Dictionary<Type, IFixedWidthConverter>()
        {
            {typeof(int), new IntConverter()},
            {typeof(string), new StringConverter()},
            {typeof(double), new DoubleConverter()}
        };

        public static object GetForType(Type t)
        {
            return Converters[t];
        }
    }
}