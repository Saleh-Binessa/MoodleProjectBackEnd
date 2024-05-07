using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using MoodleBackEnd.Models.Entites.Users;

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
            modelBuilder.Entity<StudentEntity>()
       .HasOne(s => s.Course)
       .WithMany(c => c.Students)
       .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<PhaseEntity>()
                .HasOne(p => p.Course)
                .WithMany(c => c.Phases)
                .HasForeignKey(p => p.CourseId);

            modelBuilder.Entity<PhaseMaterial>()
                .HasKey(pm => new { pm.PhaseId, pm.MaterialId });

            modelBuilder.Entity<PhaseMaterial>()
                .HasOne(pm => pm.Phase)
                .WithMany(p => p.Materials)
                .HasForeignKey(pm => pm.PhaseId);

            modelBuilder.Entity<PhaseMaterial>()
                .HasOne(pm => pm.Material)
                .WithMany(m => m.Phases)
                .HasForeignKey(pm => pm.MaterialId);

            modelBuilder.Entity<MaterialTask>()
                .HasKey(mt => new { mt.MaterialId, mt.TaskId });

            modelBuilder.Entity<MaterialTask>()
                .HasOne(mt => mt.Material)
                .WithMany(m => m.Tasks)
                .HasForeignKey(mt => mt.MaterialId);

            modelBuilder.Entity<MaterialTask>()
                .HasOne(mt => mt.Task)
                .WithMany(t => t.Materials)
                .HasForeignKey(mt => mt.TaskId);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Submission)
                .WithOne(s => s.Task)
                .HasForeignKey<SubmissionEntity>(s => s.TaskId);

            modelBuilder.Entity<SubmissionEntity>()
                .HasOne(s => s.Grade)
                .WithOne(g => g.Submission)
                .HasForeignKey<GradeEntity>(g => g.SubmissionId);
        }
    }
}
