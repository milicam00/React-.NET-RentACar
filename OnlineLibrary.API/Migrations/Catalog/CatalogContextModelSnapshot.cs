﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineRentCar.Modules.Catalog.Infrastructure;

#nullable disable

namespace OnlineRentCar.API.Migrations.Catalog
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions.Car", b =>
                {
                    b.Property<Guid>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<double>("DailyRate")
                        .HasColumnType("float");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Mileage")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberOfDoors")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPassangers")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRatings")
                        .HasColumnType("int");

                    b.Property<string>("TransmissionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("LocationId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ClientId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocationId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions.Owner", b =>
                {
                    b.Property<Guid>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OwnerId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription.RentalCar", b =>
                {
                    b.Property<Guid>("RentalCarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommentOfOwner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("int");

                    b.Property<int?>("RatedRating")
                        .HasColumnType("int");

                    b.Property<double>("RentalCost")
                        .HasColumnType("float");

                    b.Property<Guid>("RentalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Returned")
                        .HasColumnType("bit");

                    b.Property<string>("TextualComment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RentalCarId");

                    b.HasIndex("CarId");

                    b.HasIndex("RentalId");

                    b.ToTable("RentalCars");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription.Rental", b =>
                {
                    b.Property<Guid>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RentalId");

                    b.HasIndex("ClientId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions.Car", b =>
                {
                    b.HasOne("OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions.Location", "Location")
                        .WithMany("Cars")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions.Location", b =>
                {
                    b.HasOne("OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions.Owner", "Owner")
                        .WithMany("Locations")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription.RentalCar", b =>
                {
                    b.HasOne("OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions.Car", "Car")
                        .WithMany("RentalCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription.Rental", "Rental")
                        .WithMany("RentalCars")
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription.Rental", b =>
                {
                    b.HasOne("OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions.Car", b =>
                {
                    b.Navigation("RentalCars");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions.Location", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions.Owner", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription.Rental", b =>
                {
                    b.Navigation("RentalCars");
                });
#pragma warning restore 612, 618
        }
    }
}
