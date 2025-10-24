namespace SignalLab.Core.Logging;

public class ConsoleLogger : ILogger
{
    public void Log(string message, LogType type = LogType.Info)
    {
        var date = DateTime.Now;
        Console.ForegroundColor = GetColor(type);

        Console.WriteLine($"[{type.ToString().ToUpper()}][{date:HH:mm:ss}]: {message}");
        
        Console.ResetColor();
    }

    private ConsoleColor GetColor(LogType type)
    {
        return type switch
        {
            LogType.Info => ConsoleColor.Gray,
            LogType.Warning => ConsoleColor.Yellow,
            LogType.Error => ConsoleColor.Red,
            _ => ConsoleColor.White
        };
    }
}