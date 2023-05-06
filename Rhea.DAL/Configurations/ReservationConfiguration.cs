using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rhea.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.DAL.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("reservation");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(w => w.Reservation)
                .HasForeignKey(x => x.IdUser);

            builder.HasOne(x => x.User)
                .WithMany(w => w.Reservation)
                .HasForeignKey(x => x.IdUser);

            builder.HasOne(x => x.Event)
                .WithMany(w => w.Reservation)
                .HasForeignKey(x => x.IdEvent);

            builder.HasOne(x => x.ReservationStatus)
               .WithMany(w => w.Reservation)
               .HasForeignKey(x => x.IdReservationStatus);
        }
    }
}
