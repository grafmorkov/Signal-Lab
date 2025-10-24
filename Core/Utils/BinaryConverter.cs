using System.Text;

namespace SignalLab.Core.Utils;

public static class BinaryConverter
{
    public static string ConvertToBinary(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;


        byte[] bytes = Encoding.UTF8.GetBytes(text);
        return string.Concat(bytes.SelectMany(b => Convert.ToString(b, 2).PadLeft(8, '0')));
    }
}