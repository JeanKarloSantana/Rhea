using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rhea.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.DAL.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("events");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.EventType)
                .WithMany(w => w.Event)
                .HasForeignKey(x => x.IdEventType);

            builder.HasOne(x => x.EventStatus)
                .WithMany(w => w.Event)
                .HasForeignKey(x => x.IdEventStatus);

        }
    }
}
