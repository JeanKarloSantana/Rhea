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
    public class FurnitureConfiguration : IEntityTypeConfiguration<Furniture>
    {
        public void Configure(EntityTypeBuilder<Furniture> builder)
        {
            builder.ToTable("furnitures");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.FurnitureStatus)
                .WithMany(w => w.Furniture)
                .HasForeignKey(w => w.IdFurnitureStatus);
        }
    }
}
