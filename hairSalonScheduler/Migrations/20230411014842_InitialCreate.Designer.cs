﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace hairSalonScheduler.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230411014842_InitialCreate")]
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
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("longtext");

                    b.Property<string>("ApptType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CurrentHairPhotoPath")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StylistID")
                        .HasColumnType("int");

                    b.Property<int?>("TheUserID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time(6)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StylistID");

                    b.HasIndex("TheUserID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.PromotionalPricing", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountedPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ServiceID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("StylistID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StylistID");

                    b.ToTable("PromotionalPricings");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.SocialMediaAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SocialMediaType")
                        .HasColumnType("int");

                    b.Property<int>("StylistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StylistId");

                    b.ToTable("SocialMediaAccount");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.Stylist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Stylists");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.StylistHours", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time(6)");

                    b.Property<int>("StylistID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StylistID");

                    b.ToTable("StylistHours");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.StylistService", b =>
                {
                    b.Property<int>("StylistID")
                        .HasColumnType("int");

                    b.Property<int>("ServiceID")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.HasKey("StylistID", "ServiceID");

                    b.HasIndex("ServiceID");

                    b.ToTable("StylistService");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.TheService", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AppointmentID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.TheUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Allergies")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PreferredPronouns")
                        .HasColumnType("longtext");

                    b.Property<int?>("PreferredStylistID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.Appointment", b =>
                {
                    b.HasOne("hairSalonScheduler.Models.Stylist", null)
                        .WithMany("Appointments")
                        .HasForeignKey("StylistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hairSalonScheduler.Models.TheUser", null)
                        .WithMany("Appointments")
                        .HasForeignKey("TheUserID");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.PromotionalPricing", b =>
                {
                    b.HasOne("hairSalonScheduler.Models.Stylist", null)
                        .WithMany("PromotionalPricings")
                        .HasForeignKey("StylistID");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.SocialMediaAccount", b =>
                {
                    b.HasOne("hairSalonScheduler.Models.Stylist", "Stylist")
                        .WithMany("SocialMediaAccounts")
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.StylistHours", b =>
                {
                    b.HasOne("hairSalonScheduler.Models.Stylist", "Stylist")
                        .WithMany("WorkingHours")
                        .HasForeignKey("StylistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.StylistService", b =>
                {
                    b.HasOne("hairSalonScheduler.Models.TheService", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hairSalonScheduler.Models.Stylist", "Stylist")
                        .WithMany("AvailableServices")
                        .HasForeignKey("StylistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.TheService", b =>
                {
                    b.HasOne("hairSalonScheduler.Models.Appointment", null)
                        .WithMany("Services")
                        .HasForeignKey("AppointmentID");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.Appointment", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.Stylist", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("AvailableServices");

                    b.Navigation("PromotionalPricings");

                    b.Navigation("SocialMediaAccounts");

                    b.Navigation("WorkingHours");
                });

            modelBuilder.Entity("hairSalonScheduler.Models.TheUser", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
