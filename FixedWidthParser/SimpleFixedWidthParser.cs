using System;
using System.Collections.Generic;
using System.IO;
using FixedWidthParser.Converters;
using FixedWidthParser.Extensions;

namespace FixedWidthParser
{
    public static class SimpleFixedWidthParser
    {
        public static List<T> ParseFile<T>(string path) where T: new()
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var lines = File.ReadAllLines(path);
            return ParseStringArray<T>(lines);
        }

        public static List<T> ParseStringArray<T>(string[] lines) where T : new()
        {
            if (lines == null)
            {
                throw new ArgumentNullException(nameof(lines));
            }
            
            var list = new List<T>();
            var props = typeof(T).GetFixedWidthAttributedProperties();
            
            foreach (var line in lines)
            {
                var e = new T();
                foreach (var propertyInfo in props)
                {
                    var attribute = propertyInfo.GetFixedWidthAttribute();
                    var str = line.Substring(attribute.From, attribute.Length);
                    
                    if (attribute.Converter != null)
                    {
                        propertyInfo.SetValue(e, Utils.Convert(attribute.Converter, str), null);
                    }
                    else
                    {
                        propertyInfo.SetValue(e, Utils.ConvertWithConverter(ConverterMap.GetForType(propertyInfo.PropertyType), str), null);
                    }
                }
                list.Add(e);
            }
            return list;
        } 
    }
}