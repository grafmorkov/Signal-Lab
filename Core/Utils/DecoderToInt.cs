namespace SignalLab.Core.Utils;

public static class DecoderToInt
{
    public static List<int> DecodeString(string inf)
    {
        var result = new List<int>();
        if (string.IsNullOrEmpty(inf))
            return result;

        foreach (char c in inf)
        {
            if (c == '0')
                result.Add(0);
            else if (c == '1')
                result.Add(1);
        }
        return result;
    }
}