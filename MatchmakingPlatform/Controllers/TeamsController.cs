using MatchmakingPlatform.Application.Interface;
using MatchmakingPlatform.Application.Services;
using MatchmakingPlatform.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MatchmakingPlatform.Controllers
{
    [Route("[controller]")]
    public class TeamsController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public ActionResult CreateTeam([FromBody] CreateTeamDto teamDto)
        {
            var team = _teamService.CreateTeam(teamDto);
            return Ok(team);
        }

        [HttpGet("{id}")]
        public ActionResult GetTeam(Guid id)
        {
            var team = _teamService.GetTeam(id);
            return Ok(team);
        }
    }
}
