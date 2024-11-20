using MatchmakingPlatform.Domain.Interfaces;
using MatchmakingPlatform.Domain.Models;
using MatchmakingPlatform.Infastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MatchmakingPlatform.Infastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly MatchmakingPlatformContext _context;

        public TeamRepository(MatchmakingPlatformContext context)
        {
            _context = context;
        }

        public Team CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();

            return team;
        }

        public Team TeamExists(string teamname)
        {
            var team = _context.Teams.FirstOrDefault(p => p.Teamname == teamname);
            return team;
        }

        public Team GetTeamByName(string teamName)
        {
            return _context.Teams.Include(t => t.Players)
                                 .FirstOrDefault(t => t.Teamname == teamName);
        }
    }
}
