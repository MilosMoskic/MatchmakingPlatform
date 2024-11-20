using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Domain.Interfaces
{
    public interface ITeamRepository
    {
        Team CreateTeam(Team team);
        Team TeamExists(string teamname);
        Team GetTeamByName(string teamName);
    }
}
