using Microsoft.Identity.Client;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Swinford.Logging
{
    public class LoggerConfig
    {
        public string TimestampFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";
        public TimeZoneInfo TimestampTimeZone { get; set; } = TimeZoneInfo.Local;
        public string LogFilePath { get; set; } = "log.txt";
        public bool LogToConsole { get; set; } = true;
        public LogLevel MinimumLevel { get; set; } = LogLevel.Debug;
    }

    public enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Fatal = 4
    }

    public sealed class Logger
    {
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());
        private static readonly object _lock = new object();

        private LoggerConfig _config;

        private Logger()
        {
            _config = new LoggerConfig(); // default config
        }

        public static Logger Instance => _instance.Value;

        public void Configure(LoggerConfig config)
        {
            lock (_lock)
            {
                _config = config;
            }
        }

        public void Log(LogLevel level, string message, string scope = null)
        {
            if (level < _config.MinimumLevel)
                return;

            string formattedMessage = $"{level.ToString().ToUpper()}: {message}";
            LogInternal(formattedMessage, _config.LogFilePath, scope);
        }

        public void LogToFile(LogLevel level, string message, string overrideFilePath, string scope = null)
        {
            if (level < _config.MinimumLevel)
                return;

            string formattedMessage = $"{level.ToString().ToUpper()}: {message}";
            LogInternal(formattedMessage, overrideFilePath, scope);
        }

        private void LogInternal(string message, string filePath, string scope)
        {
            string timestamp = TimeZoneInfo.ConvertTime(DateTime.Now, _config.TimestampTimeZone)
                                           .ToString(_config.TimestampFormat);

            string scopeText = string.IsNullOrWhiteSpace(scope) ? "" : $"[{scope}] ";
            string logEntry = $"[{timestamp}] {scopeText}{message}";

            lock (_lock)
            {
                try
                {
                    File.AppendAllText(filePath, logEntry + Environment.NewLine, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Logger error writing to file: {ex.Message}");
                }

                if (_config.LogToConsole)
                {
                    Console.WriteLine(logEntry);
                }
            }
        }
    }
    public static class Log
    {
        public static void Debug(string message, [CallerMemberName] string scope = null)
            => Logger.Instance.Log(LogLevel.Debug, message, scope);
        public static void Info(string message, [CallerMemberName] string scope = null)
            => Logger.Instance.Log(LogLevel.Info, message, scope);
        public static void Warning(string message, [CallerMemberName] string scope = null)
            => Logger.Instance.Log(LogLevel.Warning, message, scope);
        public static void Error(string message, [CallerMemberName] string scope = null)
            => Logger.Instance.Log(LogLevel.Error, message, scope);
        public static void Fatal(string message, [CallerMemberName] string scope = null)
            => Logger.Instance.Log(LogLevel.Fatal, message, scope);
        public static void ToFile(LogLevel level, string message, string filePath, [CallerMemberName] string scope = null)
            => Logger.Instance.LogToFile(level, message, filePath, scope);
    }

}
