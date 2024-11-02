using Microsoft.EntityFrameworkCore;
using TeamService.Models.Entities;

namespace TeamService.Persistence
{
    public class TeamDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamParticipant> TeamParticipants { get; set; }

        public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
