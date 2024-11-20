using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Domain.Interfaces
{
    public interface IMatchRepository
    {
        Match CreateMatch(Match match);
    }
}
