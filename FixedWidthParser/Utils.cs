using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using FixedWidthParser.Converters;
using FixedWidthParser.Extensions;

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

        public static object CreateConverterFromType(Type typeConverter)
        {
            if (typeConverter == null)
            {
                return null;
            }

            var converter = Utils.CreateFixedWitdhConverter(typeConverter);
            if (converter is IFixedWidthConverter fixedWidthConverter && !fixedWidthConverter.CanConvertFrom)
            {
                return null;
            }
            return converter;
        }

        public static int CheckMinStringWidth(IEnumerable<PropertyInfo> infos)
        {
            var attributes = infos.Select(info => info.GetFixedWidthAttribute());
            var attribute = attributes.Aggregate(
                (first, second) => (first.From + first.Length) > (second.From + second.Length)
                    ? first
                    : second);
            return attribute.From + attribute.Length;
        }
    }
}