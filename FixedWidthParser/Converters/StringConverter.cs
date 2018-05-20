namespace FixedWidthParser.Converters
{
    public class StringConverter : IFixedWidthConverter<string>
    {
        public string From(string input)
        {
            return input.Trim();
        }

        public string To(string output, int width)
        {
            if (string.IsNullOrWhiteSpace(output))
            {
                output = "";
            }
            return output.PadRight(width);
        }

        public bool CanConvertFrom => true;
        public bool CanConvertTo => true;
    }
}