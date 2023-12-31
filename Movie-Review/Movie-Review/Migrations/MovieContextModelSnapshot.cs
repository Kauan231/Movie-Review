﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movie_Review.Data;

#nullable disable

namespace Movie_Review.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Movie_Review.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Actors")
                        .HasColumnType("longtext");

                    b.Property<string>("Awards")
                        .HasColumnType("longtext");

                    b.Property<string>("BoxOffice")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("DVD")
                        .HasColumnType("longtext");

                    b.Property<string>("Director")
                        .HasColumnType("longtext");

                    b.Property<string>("Genre")
                        .HasColumnType("longtext");

                    b.Property<string>("Language")
                        .HasColumnType("longtext");

                    b.Property<string>("Metascore")
                        .HasColumnType("longtext");

                    b.Property<string>("Plot")
                        .HasColumnType("longtext");

                    b.Property<string>("Poster")
                        .HasColumnType("longtext");

                    b.Property<string>("Production")
                        .HasColumnType("longtext");

                    b.Property<string>("Rated")
                        .HasColumnType("longtext");

                    b.Property<string>("Ratings")
                        .HasColumnType("longtext");

                    b.Property<string>("Released")
                        .HasColumnType("longtext");

                    b.Property<string>("Response")
                        .HasColumnType("longtext");

                    b.Property<string>("Runtime")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<string>("Website")
                        .HasColumnType("longtext");

                    b.Property<string>("Writer")
                        .HasColumnType("longtext");

                    b.Property<string>("Year")
                        .HasColumnType("longtext");

                    b.Property<string>("imdbID")
                        .HasColumnType("longtext");

                    b.Property<string>("imdbRating")
                        .HasColumnType("longtext");

                    b.Property<string>("imdbVotes")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
