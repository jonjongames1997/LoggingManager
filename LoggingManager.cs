using System;
using System.IO;
using Rage;
using JMCalloutsRemastered.Utilities;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JMCalloutsRemastered.Stuff
{
    internal static class LoggingManager
    {
        private const string LoggingPrefix = "JMCalloutsRemastered";
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins/LSPDFR/JMCalloutsRemastered/Log/JMCalloutsRemastered.log");

        internal enum LogLevel
        {
            Debug,
            Info,
            Warning,
            Error
        }

        internal static void Log(string message, LogLevel level = LogLevel.Info)
        {
            string logMessage = $"{LoggingPrefix} [{level}]: {message}";

            // Log to file
            try
            {
                File.AppendAllText(LogFilePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {logMessage}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                Game.LogTrivial($"{LoggingPrefix} [Error]: Failed to write to log file: {ex.Message}");
            }

            // Log based on level
            switch (level)
            {
                case LogLevel.Debug:
                    if (Globals.theApplication.debugLogging)
                    {
                        Game.LogTrivial(logMessage);
                    }
                    break;

                case LogLevel.Info:
                case LogLevel.Warning:
                case LogLevel.Error:
                    Game.LogTrivial(logMessage);
                    break;
            }
        }

        internal static void Normal(string msg)
        {
            string logMessage = $"[NORMAL] JMCallouts Remasterd: {msg}";
            try
            {
                File.AppendAllText(LogFilePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {logMessage}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                Game.LogTrivial($"{LoggingPrefix} [Error]: Failed to write to log file: {ex.Message}");
            }
            Game.LogTrivial(logMessage);
        }
    }
}
