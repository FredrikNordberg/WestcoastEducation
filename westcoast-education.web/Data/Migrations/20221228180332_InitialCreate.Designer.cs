﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using westcoast_education.web.Data;

#nullable disable

namespace westcoasteducation.web.Data.Migrations
{
    [DbContext(typeof(WestcoastEducationContext))]
    [Migration("20221228180332_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("westcoast_education.web.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CouseLanguage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("westcoast_education.web.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentPhone")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("westcoast_education.web.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeacherEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TeacherFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TeacherLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherPhone")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
