using MatchmakingPlatform.Application.Interface;
using MatchmakingPlatform.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MatchmakingPlatform.Controllers
{
    [Route("[controller]")]
    public class MatchesController : Controller
    {
        private readonly IMatchService _matchService;

        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpPost]
        public ActionResult CreateMatch([FromBody] CreateMatchDto createMatchDto)
        {
            _matchService.CreateMatch(createMatchDto);
            return Ok();
        }
    }
}
