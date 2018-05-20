namespace FixedWidthParser.Converters
{

    public interface IFixedWidthConverter
    {
        bool CanConvertFrom { get; }
        bool CanConvertTo { get; }
    }
    
    public interface IFixedWidthConverter<T> : IFixedWidthConverter
    {
        T From(string input);

        string To(T output, int width);
    }
}