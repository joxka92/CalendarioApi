using Application.Logger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class LoggerExtensions
    {
        public static void AddCustomLoggerProvider(this ILoggingBuilder builder, string path)
        {
            builder.AddProvider(new LoggerProvider(path));
        }
    }
}
