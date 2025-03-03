using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.UnitOfWork
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        private readonly AppContext _context;
        public UnitOfWork(AppContext context)
        {
            _context = context;
        }

        public AppContext Context
        {
            get => _context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
       

        public IDbContextTransaction CreateTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
