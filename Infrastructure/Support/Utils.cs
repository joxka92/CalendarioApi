using Microsoft.Kiota.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Support
{
    public class Utils
    {
        public static bool IsDateType(object obj)
        {
            Type type = obj.GetType();
            if (type == typeof(DateTime))
                return true;

            return false;
        }

    }
}
