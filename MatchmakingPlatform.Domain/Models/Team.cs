using System.ComponentModel.DataAnnotations;

namespace MatchmakingPlatform.Domain.Models
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        public string Teamname { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
