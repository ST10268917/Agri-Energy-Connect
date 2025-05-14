namespace Agri_Energy_Connect.Services
{
    using System;
    using System.IO;

    public sealed class AppLogger
    {
        private static readonly Lazy<AppLogger> _instance = new(() => new AppLogger());
        private static readonly object _lock = new();

        private string logFilePath;

        private AppLogger()
        {
            var logDir = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(logDir);
            logFilePath = Path.Combine(logDir, "app_log.txt");
        }

        public static AppLogger Instance => _instance.Value;

        public void Log(string message)
        {
            lock (_lock)
            {
                File.AppendAllText(logFilePath, $"{DateTime.Now:G} - {message}{Environment.NewLine}");
            }
        }
    }

}
