using MatchmakingPlatform.Domain.Dto;
using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Application.Interface
{
    public interface IPlayerService
    {
        PlayerDetails CreatePlayer(CreatePlayerDto createPlayerDto);
        PlayerDetails GetPlayer(Guid id);
    }
}
