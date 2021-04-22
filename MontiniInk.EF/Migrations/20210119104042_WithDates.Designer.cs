﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MontiniInk.EF;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MontiniInk.EF.Migrations
{
    [DbContext(typeof(MontiniInkContext))]
    [Migration("20210119104042_WithDates")]
    partial class WithDates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("MontiniInk.Model.BlogPost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ImgLink")
                        .HasColumnType("text");

                    b.Property<string>("Nachname")
                        .HasColumnType("text");

                    b.Property<string>("Titel")
                        .HasColumnType("text");

                    b.Property<string>("Vorname")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MontiniInk.Model.Request", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Anfrage")
                        .HasColumnType("text");

                    b.Property<DateTime>("Appointment")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Handled")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("MontiniInk.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
