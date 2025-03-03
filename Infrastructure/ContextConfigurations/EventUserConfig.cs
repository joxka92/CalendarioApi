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
    public class EventUserConfig : IEntityTypeConfiguration<EventUser>
    {
        public void Configure(EntityTypeBuilder<EventUser> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("T_Evento_Usuario");

        }
    }
}
