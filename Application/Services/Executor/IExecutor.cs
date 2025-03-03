using Infrastructure.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Executor
{
    public interface IExecutor
    {
        Response<T> SafeExecutor<T>(Func<T> action, string errMsg = "");
        Task<Response<T>> SafeAwaitExecutor<T>(Func<Task<T>> action, string errMsg = "");
    }
}
