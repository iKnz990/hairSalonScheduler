﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace hairSalonScheduler.Migrations
{
    [DbContext(typeof(SalonDbContext))]
    [Migration("20230427004800_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("hairSalonScheduler.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ContactInformation")
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceName")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("LoyaltyPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Availability")
                        .HasColumnType("longtext");

                    b.Property<string>("Category")
                        .HasColumnType("longtext");

                    b.Property<string>("StaffIds")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.Stylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Stylists");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.StylistAvailability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time(6)");

                    b.Property<int>("StylistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StylistId");

                    b.ToTable("StylistAvailabilities");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.StylistAvailability", b =>
                {
                    b.HasOne("hairSalonScheduler.Models.Stylist", "Stylist")
                        .WithMany("Availabilities")
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.Stylist", b =>
                {
                    b.Navigation("Availabilities");
                });
#pragma warning restore 612, 618
        }
    }
}
