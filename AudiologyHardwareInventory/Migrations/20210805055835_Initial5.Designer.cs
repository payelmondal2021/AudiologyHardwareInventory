﻿// <auto-generated />
using System;
using AudiologyHardwareInventory.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AudiologyHardwareInventory.Migrations
{
    [DbContext(typeof(HardwareInventoryContext))]
    [Migration("20210805055835_Initial5")]
    partial class Initial5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AudiologyHardwareInventory.Models.ChipSet", b =>
                {
                    b.Property<int>("ChipSetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChipSetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChipSetId");

                    b.ToTable("ChipsSet");
                });

            modelBuilder.Entity("AudiologyHardwareInventory.Models.HardwareType", b =>
                {
                    b.Property<int>("HardwareTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HardwareName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HardwareTypeId");

                    b.ToTable("HardwareType");
                });

            modelBuilder.Entity("AudiologyHardwareInventory.Models.HearingAId", b =>
                {
                    b.Property<int>("HearingAidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirmwareVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HearingAidName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<int?>("PlatformId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Side")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("HearingAidId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PlatformId");

                    b.HasIndex("TeamId");

                    b.ToTable("HearingAId");
                });

            modelBuilder.Entity("AudiologyHardwareInventory.Models.Images", b =>
                {
                    b.Property<int>("ImageUrlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HearingAidNumberHearingAidId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageUrlId");

                    b.HasIndex("HearingAidNumberHearingAidId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("AudiologyHardwareInventory.Models.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufacturerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("AudiologyHardwareInventory.Models.Mobile", b =>
                {
                    b.Property<int>("MobileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChipSetId")
                        .HasColumnType("int");

                    b.Property<string>("DisplayInInches")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OSVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessorArchitecture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resolution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupportedProtocol")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("MobileId");

                    b.HasIndex("ChipSetId");

                    b.HasIndex("TeamId");

                    b.ToTable("Mobile");
                });

            modelBuilder.Entity("AudiologyHardwareInventory.Models.MobileModels", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModelId");

                    b.ToTable("MobileModels");
                });

            modelBuilder.Entity("AudiologyHardwareInventory.Models.Platform", b =>
                {
                    b.Property<int>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlatformName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlatformId");

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("AudiologyHardwareInventory.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("AudiologyHardwareInventory.Models.HearingAId", b =>
                {
                    b.HasOne("AudiologyHardwareInventory.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("AudiologyHardwareInventory.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId");

                    b.HasOne("AudiologyHardwareInventory.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("Manufacturer");

                    b.Navigation("Platform");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("AudiologyHardwareInventory.Models.Images", b =>
                {
                    b.HasOne("AudiologyHardwareInventory.Models.HearingAId", "HearingAidNumber")
                        .WithMany()
                        .HasForeignKey("HearingAidNumberHearingAidId");

                    b.Navigation("HearingAidNumber");
                });

            modelBuilder.Entity("AudiologyHardwareInventory.Models.Mobile", b =>
                {
                    b.HasOne("AudiologyHardwareInventory.Models.ChipSet", "ChipSet")
                        .WithMany()
                        .HasForeignKey("ChipSetId");

                    b.HasOne("AudiologyHardwareInventory.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("ChipSet");

                    b.Navigation("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
