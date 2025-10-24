namespace SignalLab.Core.Logging;

public interface ILogger
{
    void Log(string message, LogType type = LogType.Info);
}