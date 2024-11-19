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
    }
}
