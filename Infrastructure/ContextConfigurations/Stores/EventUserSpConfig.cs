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
    public class EventUserSpConfig : IEntityTypeConfiguration<EventUserStore>
    {
        public void Configure(EntityTypeBuilder<EventUserStore> builder)
        {
            builder.HasNoKey();
        }
    }

    public class EventSeriadoSpConfig : IEntityTypeConfiguration<ListEventSerializado>
    {
        public void Configure(EntityTypeBuilder<ListEventSerializado> builder)
        {
            builder.HasNoKey();
        }
    }

    public class UsuariosSpConfig : IEntityTypeConfiguration<UserCalendar>
    {
        public void Configure(EntityTypeBuilder<UserCalendar> builder)
        {
            builder.HasNoKey();
        }
    }
}
