using Domain.Models;
using Domain.Models.CalendarUser;
using Domain.Models.EventUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ContextConfigurations.Stores
{
    public class TypeEventConfig : IEntityTypeConfiguration<TypeEvent>
    {
        public void Configure(EntityTypeBuilder<TypeEvent> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("C_Tipo_Evento");

        }
    }
}
