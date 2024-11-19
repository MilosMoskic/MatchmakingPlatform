namespace MatchmakingPlatform.Domain.Dto
{
    public class PlayerDetails
    {
        public Guid Id { get; set; }
        public string? Nickname { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Elo { get; set; }
        public int HoursPlayed { get; set; }
        public string? Team { get; set; }
        public int? RatingAdjustment { get; set; }
    }
}
