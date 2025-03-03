using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Support
{
    public class Response<T>
    {
        public Response()
        {
            Result = new()
            {
                Status = true
            };

        }

        public StatusRequest Result { get; set; }

        public T Data { get; set; }

        public static implicit operator T(Response<T> value)
        {
            return value.Data;
        }

        public static implicit operator Response<T>(T value)
        {
            return new Response<T> { Data = value };
        }
    }

    public class StatusRequest
    {
        public string Error { get; set; }
        public bool Status { get; set; }
    }

}
