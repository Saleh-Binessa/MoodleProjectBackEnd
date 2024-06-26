﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoodleBackEnd.Models.Entites;

#nullable disable

namespace MoodleBackEnd.Migrations
{
    [DbContext(typeof(MoodleContext))]
    [Migration("20240508074236_intialize")]
    partial class intialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseEntityStudentEntity", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsStudentId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "StudentsStudentId");

                    b.HasIndex("StudentsStudentId");

                    b.ToTable("CourseEntityStudentEntity");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.CourseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.GradeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubmissionId")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.InstructorCourse", b =>
                {
                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("InstructorId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("InstructorCourse");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.MaterialEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhaseId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhaseId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.PhaseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Phases");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.SubmissionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<string>("SubmissionLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskEntityId")
                        .IsUnique();

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.TaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubmissionEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.Users.AdminEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("AdminEntity");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.Users.InstructorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.Users.StudentEntity", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserAccountId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.Users.UserAccountEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("CourseEntityStudentEntity", b =>
                {
                    b.HasOne("MoodleBackEnd.Models.Entites.CourseEntity", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoodleBackEnd.Models.Entites.Users.StudentEntity", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.GradeEntity", b =>
                {
                    b.HasOne("MoodleBackEnd.Models.Entites.SubmissionEntity", "Submission")
                        .WithOne("Grade")
                        .HasForeignKey("MoodleBackEnd.Models.Entites.GradeEntity", "SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.InstructorCourse", b =>
                {
                    b.HasOne("MoodleBackEnd.Models.Entites.CourseEntity", "Course")
                        .WithMany("Instructors")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoodleBackEnd.Models.Entites.Users.InstructorEntity", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.MaterialEntity", b =>
                {
                    b.HasOne("MoodleBackEnd.Models.Entites.PhaseEntity", "Phase")
                        .WithMany("Materials")
                        .HasForeignKey("PhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phase");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.PhaseEntity", b =>
                {
                    b.HasOne("MoodleBackEnd.Models.Entites.CourseEntity", "Course")
                        .WithMany("Phases")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.SubmissionEntity", b =>
                {
                    b.HasOne("MoodleBackEnd.Models.Entites.TaskEntity", "Task")
                        .WithOne("Submission")
                        .HasForeignKey("MoodleBackEnd.Models.Entites.SubmissionEntity", "TaskEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.TaskEntity", b =>
                {
                    b.HasOne("MoodleBackEnd.Models.Entites.MaterialEntity", "Material")
                        .WithMany("Tasks")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.Users.AdminEntity", b =>
                {
                    b.HasOne("MoodleBackEnd.Models.Entites.Users.UserAccountEntity", "Account")
                        .WithOne("Admin")
                        .HasForeignKey("MoodleBackEnd.Models.Entites.Users.AdminEntity", "UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.Users.InstructorEntity", b =>
                {
                    b.HasOne("MoodleBackEnd.Models.Entites.Users.UserAccountEntity", "Account")
                        .WithOne("Instructor")
                        .HasForeignKey("MoodleBackEnd.Models.Entites.Users.InstructorEntity", "UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.Users.StudentEntity", b =>
                {
                    b.HasOne("MoodleBackEnd.Models.Entites.Users.UserAccountEntity", "Account")
                        .WithOne("Student")
                        .HasForeignKey("MoodleBackEnd.Models.Entites.Users.StudentEntity", "UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.CourseEntity", b =>
                {
                    b.Navigation("Instructors");

                    b.Navigation("Phases");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.MaterialEntity", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.PhaseEntity", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.SubmissionEntity", b =>
                {
                    b.Navigation("Grade")
                        .IsRequired();
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.TaskEntity", b =>
                {
                    b.Navigation("Submission")
                        .IsRequired();
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.Users.InstructorEntity", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("MoodleBackEnd.Models.Entites.Users.UserAccountEntity", b =>
                {
                    b.Navigation("Admin")
                        .IsRequired();

                    b.Navigation("Instructor")
                        .IsRequired();

                    b.Navigation("Student")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
