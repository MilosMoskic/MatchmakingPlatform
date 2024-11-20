using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Domain.Dto
{
    public class TeamDetails
    {
        public Guid Id { get; set; }
        public string Teamname { get; set; }
        public ICollection<PlayerDto> Players { get; set; }
    }
}
