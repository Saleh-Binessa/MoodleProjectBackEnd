using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using MoodleBackEnd.Models.Entites.Users;
using System.Diagnostics;

namespace MoodleBackEnd.Models.Entites
{
    public class MoodleContext : DbContext
    {
        public MoodleContext(DbContextOptions<MoodleContext> options) : base(options)
        {

        }

        public DbSet<UserAccountEntity> UserAccounts { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<InstructorEntity> Instructors { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<PhaseEntity> Phases { get; set; }
        public DbSet<MaterialEntity> Materials { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<CourseEntity>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId);

            modelBuilder.Entity<PhaseEntity>()
                .HasOne(p => p.Course)
                .WithMany(c => c.Phases)
                .HasForeignKey(p => p.CourseId);

            modelBuilder.Entity<MaterialEntity>()
          .HasOne(m => m.Phase)
          .WithMany(p => p.Materials)
          .HasForeignKey(m => m.PhaseId);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Material)
                .WithMany(m => m.Tasks)
                .HasForeignKey(t => t.MaterialId);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Submission)
                .WithOne(s => s.Task)
                .HasForeignKey<SubmissionEntity>(s => s.TaskId);

            modelBuilder.Entity<SubmissionEntity>()

                .HasOne(s => s.Grade)
                .WithOne(g => g.Submission)
                .HasForeignKey<GradeEntity>(g => g.SubmissionId);


            modelBuilder.Entity<StudentEntity>()
                .HasOne(s => s.Account)
                .WithOne(a => a.Student)
                .HasForeignKey<StudentEntity>(s => s.UserAccountId);

            modelBuilder.Entity<InstructorEntity>()
                .HasOne(i => i.Account)
                .WithOne(a => a.Instructor)
                .HasForeignKey<InstructorEntity>(i => i.UserAccountId);

            modelBuilder.Entity<AdminEntity>()
                .HasOne(a => a.Account)
                .WithOne(a => a.Admin)
                .HasForeignKey<AdminEntity>(a => a.UserAccountId);
        }
    }
    }
