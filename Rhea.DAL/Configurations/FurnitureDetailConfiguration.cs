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
    public class FurnitureDetailConfiguration : IEntityTypeConfiguration<FurnitureDetail>
    {
        public void Configure(EntityTypeBuilder<FurnitureDetail> builder)
        {
            builder.ToTable("furniture_details");

            builder.HasKey(x => new { x.IdReservation, x.IdFurniture });

            builder.HasOne(x => x.Reservation)
                .WithMany(w => w.FurnitureDetail)
                .HasForeignKey(x => x.IdReservation);

            builder.HasOne(x => x.Furniture)
                .WithMany(w => w.FurnitureDetail)
                .HasForeignKey(x => x.IdFurniture);
        }
    }
}
