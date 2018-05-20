using System;
using FixedWidthParser.Converters;

namespace FixedWidthParser
{
    public static class Utils
    {
        public static object CreateFixedWitdhConverter(Type t)
        {
            return Activator.CreateInstance(t);
        }

        public static object ConvertWithConverter(object converter, string str)
        {
            var info = converter.GetType().GetMethod("From");
            return info.Invoke(converter, new object[]{str});
        }

        public static object Convert(Type type, string str)
        {
            return ConvertWithConverter(CreateFixedWitdhConverter(type), str);
        }
    }
}