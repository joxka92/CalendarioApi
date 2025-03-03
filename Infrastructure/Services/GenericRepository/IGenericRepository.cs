using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.GenericRepository
{
    public interface IGenericRepository
    {
        T Get<T>(int id) where T : class;
        IEnumerable<T> GetCollection<T>() where T : class;
        IEnumerable<T> GetCollectionFiltered<T>(Func<T, bool> filter) where T : class;
        void Add<T>(T item) where T : class;
        void MarkPropertyAsUnmodified<T>(T item, List<string> propertys) where T: class;
        bool Update<T>(T item, Func<T> action) where T : class;
        bool Delete<T>(T item) where T : class;
        IDbContextTransaction CreateTransaction();      

    }
}
