namespace CarInfo.Services.Interfaces;

using Microsoft.Extensions.Logging;

public interface ILog
{
    void Log(LogLevel level, string message, Exception? ex = null);
}