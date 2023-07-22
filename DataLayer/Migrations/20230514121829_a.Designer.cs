﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(EFDBContext))]
    [Migration("20230514121829_a")]
    partial class a
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataLayer.Airlines", b =>
                {
                    b.Property<int>("AirlinesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("IATACode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AirlinesID");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("DataLayer.Destinations", b =>
                {
                    b.Property<int>("DestinationsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("IATACode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DestinationsID");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("DataLayer.Flights", b =>
                {
                    b.Property<int>("FlightsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AirlineID")
                        .HasColumnType("int");

                    b.Property<int>("ArrivalCityID")
                        .HasColumnType("int");

                    b.Property<int>("DepartureCityID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FlightsID");

                    b.HasIndex("AirlineID");

                    b.HasIndex("ArrivalCityID");

                    b.HasIndex("DepartureCityID");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("DataLayer.OrderedTickets", b =>
                {
                    b.Property<int>("OrderedTicketsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TicketID")
                        .HasColumnType("int");

                    b.HasKey("OrderedTicketsID");

                    b.HasIndex("OrderID");

                    b.HasIndex("TicketID");

                    b.ToTable("OrderedTickets");
                });

            modelBuilder.Entity("DataLayer.Orders", b =>
                {
                    b.Property<int>("OrdersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OrdersID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataLayer.Tickets", b =>
                {
                    b.Property<int>("TicketsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FlightID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TicketsID");

                    b.HasIndex("FlightID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("DataLayer.Users", b =>
                {
                    b.Property<int>("UsersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UsersID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataLayer.Flights", b =>
                {
                    b.HasOne("DataLayer.Airlines", "Airline")
                        .WithMany()
                        .HasForeignKey("AirlineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Destinations", "ArrivalCity")
                        .WithMany()
                        .HasForeignKey("ArrivalCityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Destinations", "DepartureCity")
                        .WithMany()
                        .HasForeignKey("DepartureCityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airline");

                    b.Navigation("ArrivalCity");

                    b.Navigation("DepartureCity");
                });

            modelBuilder.Entity("DataLayer.OrderedTickets", b =>
                {
                    b.HasOne("DataLayer.Orders", "Order")
                        .WithMany("OrderedTickets")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Tickets", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("DataLayer.Orders", b =>
                {
                    b.HasOne("DataLayer.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Tickets", b =>
                {
                    b.HasOne("DataLayer.Flights", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("DataLayer.Orders", b =>
                {
                    b.Navigation("OrderedTickets");
                });
#pragma warning restore 612, 618
        }
    }
}