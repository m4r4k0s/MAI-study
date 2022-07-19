using System;
using System.IO;

namespace ConsoleApp1
{
    public static class Logger
    {
        public static Action<string> WriteMessage;
        public static Severity LogLevel { get; set; } = Severity.Warning;
        public enum Severity
        {
            Verbose,
            Trace,
            Information,
            Warning,
            Error,
            Critical
        }
        public static void LogMessage(Severity s, string component, string msg)
        {
            if (s < LogLevel)
                return;

            var outputMsg = $"{DateTime.Now}\t{s}\t{component}\t{msg}";
            WriteMessage(outputMsg);
        }
    }
    public static class LoggingMethods
    {
        public static void LogToConsole(string message)
        {
            Console.Error.WriteLine(DateTime.Now.ToString() + " : " + message);
        }
    }
    public class FileLogger
    {
        private readonly string logPath;
        public FileLogger(string path)
        {
            logPath = path;
            Logger.WriteMessage += LogMessage;
        }

        public void DetachLog() => Logger.WriteMessage -= LogMessage;
        // make sure this can't throw.
        private void LogMessage(string msg)
        {
            try
            {
                using (var log = File.AppendText(logPath))
                {
                    msg = DateTime.Now.ToString() + " : " + msg;
                    log.WriteLine(msg);
                    log.Flush();
                }
            }
            catch (Exception)
            {
                // Hmm. We caught an exception while
                // logging. We can't really log the
                // problem (since it's the log that's failing).
                // So, while normally, catching an exception
                // and doing nothing isn't wise, it's really the
                // only reasonable option here.
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var file = new FileLogger("log.txt");
            Logger.WriteMessage += LoggingMethods.LogToConsole;
            string a;
            while(true){
                a = Console.ReadLine();
                Logger.WriteMessage(a);
            }
        }
    }
}
