using Application.Logger;
using Application.Support;
using Infrastructure.Support;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Executor
{
    public class Executor : IExecutor
    {
        private readonly ILogger<Executor> _logger;

        public Executor(ILogger<Executor> logger)
        {
            _logger = logger;
        }

        public Response<T> SafeExecutor<T>(Func<T> action, string errMsg = "")
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                AddLog(ex);
                return new Response<T>() { Result = new() { Error = ex.Message, Status = false } };
            }
        }

        public async Task<Response<T>> SafeAwaitExecutor<T>(Func<Task<T>> action, string errMsg = "")
        {
            try
            {
                return await action();

            }
            catch (Exception ex)
            {
                AddLog(ex);
                return new Response<T>() { Result = new() { Error = ex.Message, Status = false } };
            }
        }



        protected void AddLog(Exception ex)
        {
            _logger.BeginScope("***************** Exception Begining*****************");
            _logger.IsEnabled(LogLevel.Error);
            _logger.Log(LogLevel.Error, ex, message: ex.Message);

        }
    }
}
