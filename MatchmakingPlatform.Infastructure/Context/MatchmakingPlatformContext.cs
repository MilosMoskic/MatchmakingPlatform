using MatchmakingPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchmakingPlatform.Infastructure.Context
{
    public class MatchmakingPlatformContext : DbContext
    {
        public MatchmakingPlatformContext(DbContextOptions<MatchmakingPlatformContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasIndex(p => p.Nickname)
                .IsUnique();
        }
    }
}
