using Microsoft.EntityFrameworkCore;

namespace MatchmakingPlatform.Infastructure.Context
{
    public class MatchmakingPlatformContext : DbContext
    {
        public MatchmakingPlatformContext(DbContextOptions<MatchmakingPlatformContext> options) : base(options)
        {
        }
    }
}
