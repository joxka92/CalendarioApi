using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ContextConfigurations
{
    public class BaseConfig<T> : IEntityTypeConfiguration<T> where T : class
    {
        public BaseConfig()
        {
            
        }
        public void Configure(EntityTypeBuilder<T> builder)
        {
            throw new NotImplementedException();
        }
    }
}
