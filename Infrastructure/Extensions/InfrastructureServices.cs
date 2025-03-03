using Infrastructure.Services.GenericRepository;
using Infrastructure.Services.StoredProcedure;
using Infrastructure.Services.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class InfrastructureServices
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("db_conn"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IStoredProcedure, StoredProcedure>();

        }
    }
}
