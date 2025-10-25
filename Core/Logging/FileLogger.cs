using System;
using System.IO;

namespace SignalLab.Core.Logging;

public class FileLogger : ILogger
{
    private readonly string _path;

    public FileLogger()
    {
        _path = Path.Combine(AppContext.BaseDirectory, "log.txt");
    }

    public void Log(string message, LogType type = LogType.Info)
    {
        if (!string.IsNullOrEmpty(message))
        {
            var date = DateTime.Now;
            string resultMessage = $"[{type.ToString().ToUpper()}][{date:HH:mm:ss}]: {message}";
            File.AppendAllText(_path, resultMessage + Environment.NewLine);
        }
    }
}