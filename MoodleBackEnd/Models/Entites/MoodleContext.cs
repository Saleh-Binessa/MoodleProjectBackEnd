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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
