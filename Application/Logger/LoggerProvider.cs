using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logger
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly string _path;
        public LoggerProvider(string path)
        {
            _path = path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(categoryName, _path);

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
