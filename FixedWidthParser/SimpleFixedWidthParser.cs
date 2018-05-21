using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var propertyInfos = props as PropertyInfo[] ?? props.ToArray();
            var minStringLength = Utils.CheckMinStringWidth(propertyInfos);
            
            foreach (var line in lines)
            {
                // Check if the string has the minimal required length
                if (line.Length < minStringLength)
                {
                    // if it is too short skip this line because we can not
                    // successfully parse the line
                    continue;
                }
                
                var e = new T();
                foreach (var propertyInfo in propertyInfos)
                {
                    var attribute = propertyInfo.GetFixedWidthAttribute();
                    
                    var toConvert = line.Substring(attribute.From, attribute.Length);

                    // choose the converter to convert
                    var converter = Utils.CreateConverterFromType(attribute.Converter) 
                                       ?? ConverterMap.GetForType(propertyInfo.PropertyType);

                    propertyInfo.SetValue(e, Utils.ConvertWithConverter(converter, toConvert));
                }
                list.Add(e);
            }
            return list;
        } 
    }
}