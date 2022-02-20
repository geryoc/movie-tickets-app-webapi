﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieTicketsApp.WebApi.Shared.Database;

#nullable disable

namespace movie_tickets_app_webapi.WebApi.Shared.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieTicketsApp.WebApi.Services.Genre.Entities.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset(2)");

                    b.Property<DateTimeOffset?>("Deleted")
                        .HasColumnType("datetimeoffset(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("datetimeoffset(2)");

                    b.HasKey("Id");

                    b.ToTable("Genre", "MovieTicketApp");
                });

            modelBuilder.Entity("MovieTicketsApp.WebApi.Services.Movie.Entities.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset(2)");

                    b.Property<DateTimeOffset?>("Deleted")
                        .HasColumnType("datetimeoffset(2)");

                    b.Property<long>("GenreId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("datetimeoffset(2)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movie", "MovieTicketApp");
                });

            modelBuilder.Entity("MovieTicketsApp.WebApi.Services.Theater.Theater", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset(2)");

                    b.Property<DateTimeOffset?>("Deleted")
                        .HasColumnType("datetimeoffset(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("datetimeoffset(2)");

                    b.HasKey("Id");

                    b.ToTable("Theater", "MovieTicketApp");
                });

            modelBuilder.Entity("MovieTicketsApp.WebApi.Services.Movie.Entities.Movie", b =>
                {
                    b.HasOne("MovieTicketsApp.WebApi.Services.Genre.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
