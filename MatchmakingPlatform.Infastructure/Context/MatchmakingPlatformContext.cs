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
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasIndex(p => p.Nickname)
                .IsUnique();

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team1)
                .WithMany()
                .HasForeignKey(m => m.Team1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team2)
                .WithMany()
                .HasForeignKey(m => m.Team2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.WinningTeam)
                .WithMany()
                .HasForeignKey(m => m.WinningTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
