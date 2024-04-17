﻿// <auto-generated />
using System;
using MetersCenter.Core_.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MetersCenter.Core_.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MetersCenter.Data.MeterData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MeterPublicKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeterSerial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuppliesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuppliesId");

                    b.ToTable("MeterData");
                });

            modelBuilder.Entity("MetersCenter.Data.MeterProviders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MeterProviders");

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

            modelBuilder.Entity("MetersCenter.Data.Supplies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("InspectionEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InspectionStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InspectorUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeterProviderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UploadUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MeterProviderId");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("MetersCenter.Data.MeterData", b =>
                {
                    b.HasOne("MetersCenter.Data.Supplies", "Supplies")
                        .WithMany("MeterData")
                        .HasForeignKey("SuppliesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("MetersCenter.Data.Supplies", b =>
                {
                    b.HasOne("MetersCenter.Data.MeterProviders", "MeterProviders")
                        .WithMany("Supplies")
                        .HasForeignKey("MeterProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeterProviders");
                });

            modelBuilder.Entity("MetersCenter.Data.MeterProviders", b =>
                {
                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("MetersCenter.Data.Supplies", b =>
                {
                    b.Navigation("MeterData");
                });
#pragma warning restore 612, 618
        }
    }
}