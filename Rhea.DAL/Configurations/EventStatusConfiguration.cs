using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Rhea.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.DAL.Configurations
{
    public class EventStatusConfiguration : IEntityTypeConfiguration<EventStatus>
    {
        public void Configure(EntityTypeBuilder<EventStatus> builder)
        {
            builder.ToTable("event_statuses");

            builder.HasKey(e => e.Id);
        }
    }   
}
