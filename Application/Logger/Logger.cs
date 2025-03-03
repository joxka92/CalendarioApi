using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logger
{
    public class Logger :ILogger
    {
        private readonly string _path;
        private readonly string _categoryName;
        public Logger(string categoryName, string path)
        {
            _path = path;
            _categoryName = categoryName;
        }
        public IDisposable BeginScope<TState>(TState state) where TState : notnull => default;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message;
            if (formatter != null)
            {
                message = formatter(state, exception);
                WriteLog(message, logLevel, eventId);
            }
        }

        private void WriteLog(string message, LogLevel logLevel, EventId eventId)
        {

            try
            {
                DateTime date = DateTime.Now;
                string errorLine = @$"{Environment.NewLine} Log Level: {logLevel}; {Environment.NewLine} Event Id: {eventId.Id};{Environment.NewLine} Category: {_categoryName};{Environment.NewLine} Message: {message}";
                string nameFile = string.Format(@"{0}\{1:00}_{2:00}_{3:0000}.txt", _path, date.Day, date.Month, date.Year);
                if (File.Exists(nameFile))
                {
                    using (StreamWriter sw = File.AppendText(nameFile))
                    {
                        sw.WriteLine(errorLine);
                        sw.WriteLine($"Log Date: {date: dd/MM/yyyy HH:mm:ss}");
                        sw.WriteLine("***************************************************************");
                        sw.Close();
                    }
                }
                else File.WriteAllLines(nameFile, new string[1] { errorLine });
            }
            catch (Exception ex) { }
        }
    }
}
