using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.StoredProcedure
{
    public interface IStoredProcedure
    {
        IEnumerable<T> GetCollection<T>(string sp, params object[] parameters) where T : class;
        T GetSingleElement<T>(string sp, params object[] parameters) where T : class;
        bool Execute(string sp, params object[] parameters);
        bool ExecuteImage(string sp, params object[] parameters);
    }
}
