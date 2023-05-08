﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rhea.DAL.SQL;

#nullable disable

namespace Rhea.DAL.Migrations
{
    [DbContext(typeof(RheaDbContext))]
    partial class RheaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Rhea.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<int>("IdEventStatus")
                        .HasColumnType("int")
                        .HasColumnName("id_event_status");

                    b.Property<int>("IdEventType")
                        .HasColumnType("int")
                        .HasColumnName("id_event_type");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("IdEventStatus");

                    b.HasIndex("IdEventType");

                    b.ToTable("events", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.EventStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("event_statuses", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("event_types", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.Furniture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<int>("IdFurnitureStatus")
                        .HasColumnType("int")
                        .HasColumnName("id_furniture_status");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("IdFurnitureStatus");

                    b.ToTable("furnitures", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.FurnitureDetail", b =>
                {
                    b.Property<int>("IdReservation")
                        .HasColumnType("int")
                        .HasColumnName("id_reservation");

                    b.Property<int>("IdFurniture")
                        .HasColumnType("int")
                        .HasColumnName("id_furniture");

                    b.HasKey("IdReservation", "IdFurniture");

                    b.HasIndex("IdFurniture");

                    b.ToTable("furniture_details", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.FurnitureStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("furniture_statuses", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("NormalizedFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("normalized_first_name");

                    b.Property<string>("NormalizedLastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("normalized_last_name");

                    b.HasKey("Id");

                    b.ToTable("persons", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("end_time");

                    b.Property<int>("IdEvent")
                        .HasColumnType("int")
                        .HasColumnName("id_event");

                    b.Property<int>("IdReservationStatus")
                        .HasColumnType("int")
                        .HasColumnName("id_reservation_status");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_time");

                    b.HasKey("Id");

                    b.HasIndex("IdEvent");

                    b.HasIndex("IdReservationStatus");

                    b.HasIndex("IdUser");

                    b.ToTable("reservation", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.ReservationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("reservation_statuses", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<int>("IdUserStatus")
                        .HasColumnType("int")
                        .HasColumnName("id_user_status");

                    b.Property<int>("IdUserType")
                        .HasColumnType("int")
                        .HasColumnName("id_user_type");

                    b.HasKey("Id");

                    b.HasIndex("IdUserStatus");

                    b.HasIndex("IdUserType");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.UserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("user_statuses", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("user_types", (string)null);
                });

            modelBuilder.Entity("Rhea.Entities.Company", b =>
                {
                    b.HasOne("Rhea.Entities.User", "User")
                        .WithMany("Company")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Rhea.Entities.Event", b =>
                {
                    b.HasOne("Rhea.Entities.EventStatus", "EventStatus")
                        .WithMany("Event")
                        .HasForeignKey("IdEventStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rhea.Entities.EventType", "EventType")
                        .WithMany("Event")
                        .HasForeignKey("IdEventType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventStatus");

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("Rhea.Entities.Furniture", b =>
                {
                    b.HasOne("Rhea.Entities.FurnitureStatus", "FurnitureStatus")
                        .WithMany("Furniture")
                        .HasForeignKey("IdFurnitureStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FurnitureStatus");
                });

            modelBuilder.Entity("Rhea.Entities.FurnitureDetail", b =>
                {
                    b.HasOne("Rhea.Entities.Furniture", "Furniture")
                        .WithMany("FurnitureDetail")
                        .HasForeignKey("IdFurniture")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rhea.Entities.Reservation", "Reservation")
                        .WithMany("FurnitureDetail")
                        .HasForeignKey("IdReservation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Furniture");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Rhea.Entities.Person", b =>
                {
                    b.HasOne("Rhea.Entities.User", "User")
                        .WithMany("Person")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Rhea.Entities.Reservation", b =>
                {
                    b.HasOne("Rhea.Entities.Event", "Event")
                        .WithMany("Reservation")
                        .HasForeignKey("IdEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rhea.Entities.ReservationStatus", "ReservationStatus")
                        .WithMany("Reservation")
                        .HasForeignKey("IdReservationStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rhea.Entities.User", "User")
                        .WithMany("Reservation")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("ReservationStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Rhea.Entities.User", b =>
                {
                    b.HasOne("Rhea.Entities.UserStatus", "UserStatus")
                        .WithMany("User")
                        .HasForeignKey("IdUserStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rhea.Entities.UserType", "UserType")
                        .WithMany("User")
                        .HasForeignKey("IdUserType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserStatus");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Rhea.Entities.Event", b =>
                {
                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Rhea.Entities.EventStatus", b =>
                {
                    b.Navigation("Event");
                });

            modelBuilder.Entity("Rhea.Entities.EventType", b =>
                {
                    b.Navigation("Event");
                });

            modelBuilder.Entity("Rhea.Entities.Furniture", b =>
                {
                    b.Navigation("FurnitureDetail");
                });

            modelBuilder.Entity("Rhea.Entities.FurnitureStatus", b =>
                {
                    b.Navigation("Furniture");
                });

            modelBuilder.Entity("Rhea.Entities.Reservation", b =>
                {
                    b.Navigation("FurnitureDetail");
                });

            modelBuilder.Entity("Rhea.Entities.ReservationStatus", b =>
                {
                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Rhea.Entities.User", b =>
                {
                    b.Navigation("Company");

                    b.Navigation("Person");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Rhea.Entities.UserStatus", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Rhea.Entities.UserType", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
