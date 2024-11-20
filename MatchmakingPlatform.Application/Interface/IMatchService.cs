using MatchmakingPlatform.Domain.Dto;
using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Application.Interface
{
    public interface IMatchService
    {
        Match CreateMatch(CreateMatchDto createMatchDto);
    }
}
