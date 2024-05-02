using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace MoodleBackEnd.Models.Entites
{
    public class MoodleContext : DbContext
    {
        public MoodleContext(DbContextOptions<MoodleContext> options) : base(options)
        {

        }

        public DbSet<UserAccountEntity> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
