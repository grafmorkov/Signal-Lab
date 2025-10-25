using System.Text;
using SignalLab.Core.Logging;

namespace SignalLab.Core.Utils;

public static class BinaryConverter
{
    public static string ConvertToBinary(string text)
    {
        ILogger logger = new FileLogger();
        if (string.IsNullOrEmpty(text))
            return string.Empty;


        byte[] bytes = Encoding.UTF8.GetBytes(text);
        logger.Log($"Text: {text} has been converted to binary: {BitConverter.ToString(bytes)}.");
        return string.Concat(bytes.SelectMany(b => Convert.ToString(b, 2).PadLeft(8, '0')));
    }
}