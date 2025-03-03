using Infrastructure.Services.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.GenericRepository
{
    public class GenericRepository : IDisposable, IGenericRepository
    {

        private readonly IUnitOfWork _uow;
        public GenericRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add<T>(T item) where T : class
        {
            try
            {
                _uow.Context.Add(item);
                _uow.Commit();
            }
            catch (Exception)
            {
                _uow.Rollback();
                throw;
            }
        }

        public IDbContextTransaction CreateTransaction()
        {
            return _uow.CreateTransaction();
        }

        public T Get<T>(int id) where T: class
        {
            return _uow.Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetCollection<T>() where T : class
        {
            try
            {
                return _uow.Context.Set<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> GetCollectionFiltered<T>(Func<T, bool> filter) where T : class
        {
            try
            {
                var list = _uow.Context.Set<T>();
                return list.Where(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MarkPropertyAsUnmodified<T>(T item, List<string> propertys) where T : class
        {
            foreach (var property in propertys)
                _uow.Context.Entry(item).Property(property).IsModified = false;
        }

        public bool Update<T>(T item, Func<T> action) where T : class
        {
            try
            {
                _uow.Context.Update(item);
                action?.Invoke();
                _uow.Commit();
                return true;
            }
            catch (Exception)
            {
                _uow.Rollback();
                throw;
            }
        }

        public bool Delete<T>(T item) where T : class
        {
            try
            {
                _uow.Context.Remove(item);
                _uow.Commit();
                return true;
            }
            catch (Exception)
            {
                _uow.Rollback();
                throw;
            }
        }

        #region IDisposable Members
        public void Dispose()
        {
            if (this._uow != null)
                this._uow.Dispose();
        }
        #endregion

    }
}
