﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalUploadingMeterData.Models;

#nullable disable

namespace PortalUploadingMeterData.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240407120430_firstUpdate")]
    partial class firstUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PortalUploadingMeterData.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ElSewedy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Elster Group"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Itron"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sappel"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Arad Group"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Zenner"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Kamstrup"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Actaris"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Siemens"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Neptune Technology Group"
                        });
                });

            modelBuilder.Entity("PortalUploadingMeterData.Models.Inspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StratDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inspection");
                });

            modelBuilder.Entity("PortalUploadingMeterData.Models.MeterData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("InspectionId")
                        .HasColumnType("int");

                    b.Property<string>("MeterPublicKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MeterSerial")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UploadUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("MeterSerial", "CompanyId");

                    b.HasIndex("InspectionId");

                    b.HasIndex("CompanyId", "MeterPublicKey")
                        .IsUnique()
                        .HasFilter("[MeterPublicKey] IS NOT NULL");

                    b.ToTable("MeterData");
                });

            modelBuilder.Entity("PortalUploadingMeterData.Models.MeterData", b =>
                {
                    b.HasOne("PortalUploadingMeterData.Models.Company", "Company")
                        .WithMany("MeterData")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalUploadingMeterData.Models.Inspection", "Inspection")
                        .WithMany("MeterData")
                        .HasForeignKey("InspectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Inspection");
                });

            modelBuilder.Entity("PortalUploadingMeterData.Models.Company", b =>
                {
                    b.Navigation("MeterData");
                });

            modelBuilder.Entity("PortalUploadingMeterData.Models.Inspection", b =>
                {
                    b.Navigation("MeterData");
                });
#pragma warning restore 612, 618
        }
    }
}