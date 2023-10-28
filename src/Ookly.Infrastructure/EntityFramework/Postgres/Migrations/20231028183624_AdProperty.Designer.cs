﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Ookly.Infrastructure.EntityFramework;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231028183624_AdProperty")]
    partial class AdProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ookly.Core.AdAggregate.Ad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("Bathrooms")
                        .HasColumnType("integer");

                    b.Property<int?>("Bedrooms")
                        .HasColumnType("integer");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("character varying(40)");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("Furnished")
                        .HasColumnType("boolean");

                    b.Property<bool?>("Pets")
                        .HasColumnType("boolean");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SourceUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("State")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("Surface")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("VehicleBrandId")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("VehicleColor")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("VehicleFuelType")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<int?>("VehicleMileage")
                        .HasColumnType("integer");

                    b.Property<string>("VehicleModelId")
                        .HasColumnType("character varying(20)");

                    b.Property<int?>("VehicleYear")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.HasIndex("VehicleBrandId");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("Ookly.Core.AdAggregate.AdProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uuid");

                    b.Property<bool?>("BooleanValue")
                        .HasColumnType("boolean");

                    b.Property<string>("FilterTypeId")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("NumericValue")
                        .HasColumnType("numeric");

                    b.Property<string>("TextValue")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.HasIndex("FilterTypeId");

                    b.ToTable("AdProperty");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("CategoryTypeId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryTypeId");

                    b.HasIndex("CountryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.CategoryType", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("CategoryType");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Facet", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("FilterId")
                        .IsRequired()
                        .HasColumnType("character varying(60)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FilterId");

                    b.ToTable("Facet");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Filter", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("character varying(40)");

                    b.Property<string>("FilterTypeId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FilterTypeId");

                    b.ToTable("Filter");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.FilterType", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("ValueType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.ToTable("FilterType");
                });

            modelBuilder.Entity("Ookly.Core.VehicleBrandAggregate.VehicleBrand", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("VehicleBrands");
                });

            modelBuilder.Entity("Ookly.Core.VehicleBrandAggregate.VehicleModel", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("VehicleBrandId")
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("VehicleBrandId");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("Ookly.Core.AdAggregate.Ad", b =>
                {
                    b.HasOne("Ookly.Core.CountryAggregate.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.CountryAggregate.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.VehicleBrandAggregate.VehicleBrand", "VehicleBrand")
                        .WithMany()
                        .HasForeignKey("VehicleBrandId");

                    b.HasOne("Ookly.Core.VehicleBrandAggregate.VehicleModel", "VehicleModel")
                        .WithMany()
                        .HasForeignKey("VehicleModelId");

                    b.Navigation("Category");

                    b.Navigation("Country");

                    b.Navigation("VehicleBrand");

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("Ookly.Core.AdAggregate.AdProperty", b =>
                {
                    b.HasOne("Ookly.Core.AdAggregate.Ad", "Ad")
                        .WithMany("Properties")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.CountryAggregate.FilterType", "FilterType")
                        .WithMany()
                        .HasForeignKey("FilterTypeId");

                    b.Navigation("Ad");

                    b.Navigation("FilterType");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Category", b =>
                {
                    b.HasOne("Ookly.Core.CountryAggregate.CategoryType", "CategoryType")
                        .WithMany()
                        .HasForeignKey("CategoryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.CountryAggregate.Country", "Country")
                        .WithMany("Categories")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryType");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Facet", b =>
                {
                    b.HasOne("Ookly.Core.CountryAggregate.Filter", "Filter")
                        .WithMany("Facets")
                        .HasForeignKey("FilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filter");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Filter", b =>
                {
                    b.HasOne("Ookly.Core.CountryAggregate.Category", "Category")
                        .WithMany("Filters")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.CountryAggregate.FilterType", "FilterType")
                        .WithMany()
                        .HasForeignKey("FilterTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("FilterType");
                });

            modelBuilder.Entity("Ookly.Core.VehicleBrandAggregate.VehicleModel", b =>
                {
                    b.HasOne("Ookly.Core.VehicleBrandAggregate.VehicleBrand", null)
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleBrandId");
                });

            modelBuilder.Entity("Ookly.Core.AdAggregate.Ad", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Category", b =>
                {
                    b.Navigation("Filters");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Country", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Ookly.Core.CountryAggregate.Filter", b =>
                {
                    b.Navigation("Facets");
                });

            modelBuilder.Entity("Ookly.Core.VehicleBrandAggregate.VehicleBrand", b =>
                {
                    b.Navigation("VehicleModels");
                });
#pragma warning restore 612, 618
        }
    }
}
