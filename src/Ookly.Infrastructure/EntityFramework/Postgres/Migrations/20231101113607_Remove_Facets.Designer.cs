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
    [Migration("20231101113607_Remove_Facets")]
    partial class Remove_Facets
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ookly.Core.Entities.Ad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("character varying(40)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

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

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("Ookly.Core.Entities.AdProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uuid");

                    b.Property<bool?>("BooleanValue")
                        .HasColumnType("boolean");

                    b.Property<string>("FilterId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.Property<decimal?>("NumericValue")
                        .HasColumnType("numeric");

                    b.Property<string>("TextValue")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.HasIndex("FilterId");

                    b.ToTable("AdProperty");
                });

            modelBuilder.Entity("Ookly.Core.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Ookly.Core.Entities.CategoryFilter", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("character varying(40)");

                    b.Property<string>("FilterId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FilterId");

                    b.ToTable("CategoryFilter");
                });

            modelBuilder.Entity("Ookly.Core.Entities.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Ookly.Core.Entities.CountryCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.ToTable("CountryCategory");
                });

            modelBuilder.Entity("Ookly.Core.Entities.Filter", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("ValueType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.ToTable("Filter");
                });

            modelBuilder.Entity("Ookly.Core.Entities.Ad", b =>
                {
                    b.HasOne("Ookly.Core.Entities.CountryCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Ookly.Core.Entities.AdProperty", b =>
                {
                    b.HasOne("Ookly.Core.Entities.Ad", "Ad")
                        .WithMany("Properties")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.Entities.Filter", "FilterType")
                        .WithMany("AdProperties")
                        .HasForeignKey("FilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");

                    b.Navigation("FilterType");
                });

            modelBuilder.Entity("Ookly.Core.Entities.CategoryFilter", b =>
                {
                    b.HasOne("Ookly.Core.Entities.CountryCategory", "Category")
                        .WithMany("Filters")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.Entities.Filter", "Filter")
                        .WithMany("CategoryFilters")
                        .HasForeignKey("FilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Filter");
                });

            modelBuilder.Entity("Ookly.Core.Entities.CountryCategory", b =>
                {
                    b.HasOne("Ookly.Core.Entities.Category", "Category")
                        .WithMany("CountryCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookly.Core.Entities.Country", "Country")
                        .WithMany("Categories")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Ookly.Core.Entities.Ad", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Ookly.Core.Entities.Category", b =>
                {
                    b.Navigation("CountryCategories");
                });

            modelBuilder.Entity("Ookly.Core.Entities.Country", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Ookly.Core.Entities.CountryCategory", b =>
                {
                    b.Navigation("Filters");
                });

            modelBuilder.Entity("Ookly.Core.Entities.Filter", b =>
                {
                    b.Navigation("AdProperties");

                    b.Navigation("CategoryFilters");
                });
#pragma warning restore 612, 618
        }
    }
}
