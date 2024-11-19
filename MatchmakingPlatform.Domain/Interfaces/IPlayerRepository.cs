using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Player CreatePlayer(Player player);
        Player GetPlayer(Guid id);
        Player PlayerExists(string nickaname);
    }
}
