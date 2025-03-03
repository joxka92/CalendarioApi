using Domain.Models;
using Infrastructure.ContextConfigurations;
using Infrastructure.ContextConfigurations.Stores;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new TypeEventConfig());


            modelBuilder.ApplyConfiguration(new EventUserConfig());
            modelBuilder.ApplyConfiguration(new EventUserSpConfig());


            modelBuilder.ApplyConfiguration(new CalendarEventSeriadoConfig());
            modelBuilder.ApplyConfiguration(new CalendarEventSeriadoDaysConfig());


            modelBuilder.ApplyConfiguration(new EventSeriadoSpConfig());
            modelBuilder.ApplyConfiguration(new UsuariosSpConfig());






            base.OnModelCreating(modelBuilder);
        }
    }
}