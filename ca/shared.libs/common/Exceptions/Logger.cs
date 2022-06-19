using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace GET.PKI.Common
{
    public enum LogType
    {
        Error, Warning, Update
    }
    public static class Logger
    {
        //TODO: set the log path via user configuration from the service web admin .
        static bool EnableLogging;
        const string LOGS_DIR = "Logs";
        static Logger()
        {
            EnableLogging = false;
#if DEBUG
            if (Directory.Exists(LOGS_DIR))
                Directory.Delete(LOGS_DIR);
#endif
            Directory.CreateDirectory(LOGS_DIR);
        }
        public static void Log(string logMessage, string trace, string help, LogType logType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Date: {DateTime.Now}");
            sb.AppendLine($"Level: {logType}");
            sb.AppendLine($"Message: {logMessage}");
            sb.AppendLine($"Trace: {trace}");
            if (!string.IsNullOrWhiteSpace(help))
                sb.AppendLine($"Help: {help}");
            sb.AppendLine("******END of Message******");
            var log = sb.ToString();
            if (EnableLogging)
            {
                var logPath = $"{LOGS_DIR}/Log@{DateTime.Now:ddMMyy_hhmmmss}.txt";
                File.WriteAllText(logPath, log);
            }
            else
            {
                Debug.WriteLine(log);
            }
        }
    }
}
