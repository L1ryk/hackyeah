﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAPI.DataSource;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230930165903_Courses")]
    partial class Courses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.DataSource.Entities.Locations.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VoivodeshipId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VoivodeshipId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.Locations.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.System.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.System.Voivodeship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Voivodeships");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.Univerisites.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.Univerisites.CourseForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CourseForms");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.Univerisites.CourseLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CourseLevels");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.Univerisites.University", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ApartmentNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AvailabilityFormUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Epuap")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IconId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("JudgeRegisterId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PdfLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PersonManaging")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PromotionalFilmUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RecruitmentLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RecruitmentPageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Regon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupervisoryAuthority")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TaxId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TercCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TercDistrict")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TercVoivodeship")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VoivodeshipId")
                        .HasColumnType("uuid");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("VoivodeshipId");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.Univerisites.UniversityCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<string>("Profile")
                        .HasColumnType("text");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UniversityId");

                    b.ToTable("UniversityCourses");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.Univerisites.UniversityStatistics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("NumberCourse")
                        .HasColumnType("integer");

                    b.Property<int>("NumberEmployees")
                        .HasColumnType("integer");

                    b.Property<int>("NumberStudents")
                        .HasColumnType("integer");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("uuid");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("UniversityStatistics");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.Locations.City", b =>
                {
                    b.HasOne("WebAPI.DataSource.Entities.System.Voivodeship", "Voivodeship")
                        .WithMany()
                        .HasForeignKey("VoivodeshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voivodeship");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.System.Voivodeship", b =>
                {
                    b.HasOne("WebAPI.DataSource.Entities.Locations.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.Univerisites.University", b =>
                {
                    b.HasOne("WebAPI.DataSource.Entities.Locations.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.DataSource.Entities.Locations.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.DataSource.Entities.System.Voivodeship", "Voivodeship")
                        .WithMany()
                        .HasForeignKey("VoivodeshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Voivodeship");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.Univerisites.UniversityCourse", b =>
                {
                    b.HasOne("WebAPI.DataSource.Entities.Univerisites.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.DataSource.Entities.Univerisites.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("University");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.Univerisites.UniversityStatistics", b =>
                {
                    b.HasOne("WebAPI.DataSource.Entities.Univerisites.University", "University")
                        .WithMany("Statistics")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("WebAPI.DataSource.Entities.Univerisites.University", b =>
                {
                    b.Navigation("Statistics");
                });
#pragma warning restore 612, 618
        }
    }
}
