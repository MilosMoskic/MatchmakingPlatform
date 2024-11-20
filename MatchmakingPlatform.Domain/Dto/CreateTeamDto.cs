using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Domain.Dto
{
    public class CreateTeamDto
    {
        public string Teamname { get; set; }
        public List<Guid> Players { get; set; }
    }
}
