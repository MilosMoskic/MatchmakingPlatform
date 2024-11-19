using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Player CreatePlayer(Player player);
    }
}
