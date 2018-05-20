using System.Reflection;
using FixedWidthParser.Attributes;

namespace FixedWidthParser.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static FixedWidthRangeAttribute GetFixedWidthAttribute(this PropertyInfo info)
            => info.GetCustomAttribute<FixedWidthRangeAttribute>();
    }
}