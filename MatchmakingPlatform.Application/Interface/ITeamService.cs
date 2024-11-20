using MatchmakingPlatform.Domain.Dto;

namespace MatchmakingPlatform.Application.Interface
{
    public interface ITeamService
    {
        TeamDetails CreateTeam(CreateTeamDto teamDto);
        TeamDetails GetTeam(Guid id);
    }
}
