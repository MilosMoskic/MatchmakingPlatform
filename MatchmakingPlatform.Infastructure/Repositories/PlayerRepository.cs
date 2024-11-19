using MatchmakingPlatform.Domain.Interfaces;
using MatchmakingPlatform.Domain.Models;
using MatchmakingPlatform.Infastructure.Context;

namespace MatchmakingPlatform.Infastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly MatchmakingPlatformContext _context;
        public PlayerRepository(MatchmakingPlatformContext context)
        {
            _context = context;
        }

        public Player CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();

            return player;
        }

        public Player GetPlayer(Guid id)
        {
            var player = _context.Players.FirstOrDefault(p => p.Id == id);
            return player;
        }
    }
}
