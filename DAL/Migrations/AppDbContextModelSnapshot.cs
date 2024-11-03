﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Booking", b =>
                {
                    b.Property<Guid>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("TripID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookingID");

                    b.HasIndex("TripID");

                    b.HasIndex("UserID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Core.Entities.Location", b =>
                {
                    b.Property<Guid>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Core.Entities.Tour", b =>
                {
                    b.Property<Guid>("TourID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TourID");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("Core.Entities.TourLocation", b =>
                {
                    b.Property<Guid>("TourID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("VisitOrder")
                        .HasColumnType("int");

                    b.HasKey("TourID", "LocationID");

                    b.HasIndex("LocationID");

                    b.ToTable("TourLocations");
                });

            modelBuilder.Entity("Core.Entities.Trip", b =>
                {
                    b.Property<Guid>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxGuests")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TourID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TripID");

                    b.HasIndex("TourID");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Core.Entities.TripVehicle", b =>
                {
                    b.Property<Guid>("TripVehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<Guid>("TripID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("USageEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("USageStartTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VehicleID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TripVehicleID");

                    b.ToTable("TripVehicles");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<decimal>("VehiclePricing")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("TripVehicle", b =>
                {
                    b.Property<Guid>("TripsTripID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VehiclesVehicleID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TripsTripID", "VehiclesVehicleID");

                    b.HasIndex("VehiclesVehicleID");

                    b.ToTable("TripVehicle");
                });

            modelBuilder.Entity("Core.Entities.Booking", b =>
                {
                    b.HasOne("Core.Entities.Trip", "Trip")
                        .WithMany("Bookings")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.TourLocation", b =>
                {
                    b.HasOne("Core.Entities.Location", "Location")
                        .WithMany("TourLocations")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Tour", "Tour")
                        .WithMany("TourLocations")
                        .HasForeignKey("TourID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Core.Entities.Trip", b =>
                {
                    b.HasOne("Core.Entities.Tour", "Tour")
                        .WithMany("Trips")
                        .HasForeignKey("TourID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TripVehicle", b =>
                {
                    b.HasOne("Core.Entities.Trip", null)
                        .WithMany()
                        .HasForeignKey("TripsTripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesVehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Location", b =>
                {
                    b.Navigation("TourLocations");
                });

            modelBuilder.Entity("Core.Entities.Tour", b =>
                {
                    b.Navigation("TourLocations");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("Core.Entities.Trip", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
