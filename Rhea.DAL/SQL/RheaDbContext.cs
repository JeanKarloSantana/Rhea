using Microsoft.EntityFrameworkCore;
using Rhea.DAL.Configurations;
using Rhea.Entities;
using Rhea.Entities.ComboBox;
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
        public RheaDbContext(DbContextOptions<RheaDbContext> options) : base(options) 
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserTypeConfiguration());
            builder.ApplyConfiguration(new ReservationStatusConfiguration());
            builder.ApplyConfiguration(new FurnitureStatusConfiguration());
            builder.ApplyConfiguration(new EventTypeConfiguration());
            builder.ApplyConfiguration(new EventStatusConfiguration());
            builder.ApplyConfiguration(new UserStatusConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new FurnitureDetailConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new FurnitureConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());
        }
        
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserStatus> UserStatus { get; set; }
        public DbSet<ReservationStatus> ReservationStatuses { get; set; }
        public DbSet<FurnitureStatus> FurnitureStatuses { get; set; }
        public DbSet<EventStatus> EventStatuses { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Furniture> Furnitures { get; set;}
        public DbSet<Event> Events { get; set; }
        public DbSet<FurnitureDetail> FurnitureDetails { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
