using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Domain.Dto
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Elo { get; set; }
        public int HoursPlayed { get; set; }
        public Guid? TeamId { get; set; }
        public int? RatingAdjustment { get; set; }
    }
}
