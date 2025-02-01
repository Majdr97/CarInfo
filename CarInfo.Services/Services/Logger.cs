namespace CarInfo.Services.Services;

using System;

using Serilog;

using Microsoft.Extensions.Logging;

using CarInfo.Services.Interfaces;

public class Logger : ILog
{
    private static readonly Serilog.ILogger ErrorLogger = new LoggerConfiguration().WriteTo.File("Logs/Error/Log.txt", rollingInterval: RollingInterval.Day, shared: true).CreateLogger();
    private static readonly Serilog.ILogger DebugLogger = new LoggerConfiguration().WriteTo.File("Logs/Debug/Log.txt", rollingInterval: RollingInterval.Day, shared: true).CreateLogger();
    private static readonly Serilog.ILogger InformationLogger = new LoggerConfiguration().WriteTo.File("Logs/Info/Log.txt", rollingInterval: RollingInterval.Day, shared: true).CreateLogger();
    public void Log(LogLevel level, string message, Exception? ex = null)
    {
        var logger = level switch
        {
            LogLevel.Error => ErrorLogger,
            LogLevel.Debug => DebugLogger,
            LogLevel.Information => InformationLogger,
            _ => throw new NotImplementedException($"{level}")
        };

        Serilog.Log.Logger = logger;

        if (ex != null)
            Serilog.Log.Error(ex, message);
        else
            Serilog.Log.Information(message);
    }
}