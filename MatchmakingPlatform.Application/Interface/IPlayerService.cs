using MatchmakingPlatform.Domain.Dto;
using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Application.Interface
{
    public interface IPlayerService
    {
        Player CreatePlayer(CreatePlayerDto createPlayerDto);
    }
}
