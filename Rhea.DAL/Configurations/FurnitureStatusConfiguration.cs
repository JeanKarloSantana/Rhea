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
    public class FurnitureStatusConfiguration : IEntityTypeConfiguration<FurnitureStatus>
    {
        public void Configure(EntityTypeBuilder<FurnitureStatus> builder)
        {
            builder.ToTable("furniture_statuses");

            builder.HasKey(x => x.Id);
        }
    }
}
