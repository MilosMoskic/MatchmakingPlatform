using MatchmakingPlatform.Domain.Interfaces;
using MatchmakingPlatform.Domain.Models;
using MatchmakingPlatform.Infastructure.Context;

namespace MatchmakingPlatform.Infastructure.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly MatchmakingPlatformContext _context;

        public MatchRepository(MatchmakingPlatformContext context)
        {
            _context = context;
        }

        public Match CreateMatch(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();

            return match;
        }
    }
}
