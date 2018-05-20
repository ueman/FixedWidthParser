using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FixedWidthParser.Attributes;

namespace FixedWidthParser.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<PropertyInfo> GetFixedWidthAttributedProperties(this Type t)
        {
            return t.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(FixedWidthRangeAttribute)));
        }
    }
}