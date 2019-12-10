﻿// <auto-generated />
using System;
using IEC.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IEC.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191208140703_MovieAndGenresRelationship")]
    partial class MovieAndGenresRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("IEC.API.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Plot")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Runtime")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("IEC.API.Models.MovieGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MovieGenres");
                });

            modelBuilder.Entity("IEC.API.Models.MovieMovieGenre", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieGenreId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId", "MovieGenreId");

                    b.HasIndex("MovieGenreId");

                    b.ToTable("MovieMovieGenres");
                });

            modelBuilder.Entity("IEC.API.Models.MovieMovieGenre", b =>
                {
                    b.HasOne("IEC.API.Models.MovieGenre", "MovieGenre")
                        .WithMany("MovieMovieGenres")
                        .HasForeignKey("MovieGenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IEC.API.Models.Movie", "Movie")
                        .WithMany("MovieMovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
