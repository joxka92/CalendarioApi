using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.EventUser;

namespace Infrastructure.ContextConfigurations
{

    internal class CalendarEventSeriadoConfig : IEntityTypeConfiguration<EventSeriado>
    {
        public void Configure(EntityTypeBuilder<EventSeriado> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Navigation(e => e.Dias).AutoInclude();
            builder.ToTable("T_Evento_Seriado");
        }
    }

    internal class CalendarEventSeriadoDaysConfig : IEntityTypeConfiguration<EventSeriadoDays>
    {
        public void Configure(EntityTypeBuilder<EventSeriadoDays> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(estatus => estatus.Event)
             .WithMany(e => e.Dias)
             .HasForeignKey(eu => eu.Id_Evento_Seriado);

            builder.ToTable("R_Evento_Seriado_Dia");
        }
    }

}
