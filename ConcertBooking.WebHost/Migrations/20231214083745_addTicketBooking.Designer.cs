﻿// <auto-generated />
using System;
using ConcertBooking.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConcertBooking.WebHost.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231214083745_addTicketBooking")]
    partial class addTicketBooking
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConcertBooking.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("ConcertBooking.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ConcertId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingId");

                    b.HasIndex("ConcertId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("ConcertBooking.Entities.Concert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("VenueId");

                    b.ToTable("Concerts");
                });

            modelBuilder.Entity("ConcertBooking.Entities.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("ConcertId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("BookingId");

                    b.HasIndex("ConcertId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ConcertBooking.Entities.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("ConcertBooking.Entities.Booking", b =>
                {
                    b.HasOne("ConcertBooking.Entities.Concert", "Concert")
                        .WithMany()
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");
                });

            modelBuilder.Entity("ConcertBooking.Entities.Concert", b =>
                {
                    b.HasOne("ConcertBooking.Entities.Artist", "Artist")
                        .WithMany("Concerts")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConcertBooking.Entities.Venue", "Venue")
                        .WithMany("Concerts")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("ConcertBooking.Entities.Ticket", b =>
                {
                    b.HasOne("ConcertBooking.Entities.Booking", "Booking")
                        .WithMany("Tickets")
                        .HasForeignKey("BookingId");

                    b.HasOne("ConcertBooking.Entities.Concert", "Concert")
                        .WithMany()
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Concert");
                });

            modelBuilder.Entity("ConcertBooking.Entities.Artist", b =>
                {
                    b.Navigation("Concerts");
                });

            modelBuilder.Entity("ConcertBooking.Entities.Booking", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ConcertBooking.Entities.Venue", b =>
                {
                    b.Navigation("Concerts");
                });
#pragma warning restore 612, 618
        }
    }
}