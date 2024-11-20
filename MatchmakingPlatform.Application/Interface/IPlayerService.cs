using MatchmakingPlatform.Domain.Dto;
using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Application.Interface
{
    public interface IPlayerService
    {
        PlayerDetails CreatePlayer(CreatePlayerDto createPlayerDto);
        PlayerDetails GetPlayer(Guid id);
        void UpdatePlayerStats(Guid playerId, int hoursPlayed, int wins, int losses, double newElo);
        double CalculateNewElo(int currentElo, int opponentElo, double score, int hoursPlayed);
        int CalculateRatingAdjustment(int hoursPlayed);
    }
}
