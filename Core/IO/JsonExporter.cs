using System.IO;
using SignalLab.Core.Data;
using SignalLab.Core.Logging;

namespace SignalLab.Core.IO;

public static class JsonExporter
{
    public static void Export(Signal signal, string path)
    {
        ConsoleLogger logger = new ConsoleLogger();

        try
        {
            if (!string.IsNullOrEmpty(path))
            {
                logger.Log("The path is null or empty.", LogType.Error);
            }
        }
        catch (Exception e)
        {
            logger.Log(e.Message, LogType.Error);
            throw;
        }
    }
}