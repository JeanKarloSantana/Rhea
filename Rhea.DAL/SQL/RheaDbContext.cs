using Microsoft.EntityFrameworkCore;
using Rhea.DAL.Configurations;
using Rhea.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.DAL.SQL
{
    public class RheaDbContext : DbContext
    {
        public RheaDbContext(DbContextOptions<DbContext> options) : base(options) 
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserTypeConfiguration());
            builder.ApplyConfiguration(new ReservationStatusConfiguration());
            builder.ApplyConfiguration(new FurnitureStatusConfiguration());
            builder.ApplyConfiguration(new EventTypeConfiguration());
        }
        
        public DbSet<UserType> UserTypes => Set<UserType>();
        public DbSet<ReservationStatus> ReservationStatuses => Set<ReservationStatus>();
        public DbSet<FurnitureStatus> FurnitureStatuses => Set<FurnitureStatus>();
        public DbSet<EventType> EventTypes { get; set; }
    }
}
