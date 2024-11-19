using MatchmakingPlatform.Application.Interface;
using MatchmakingPlatform.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MatchmakingPlatform.Controllers
{
    [Route("[controller]")]
    public class PlayersController : Controller
    {
        private readonly IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost("create")]
        public ActionResult CreatePlayer([FromBody] CreatePlayerDto createPlayerDto)
        {
            _playerService.CreatePlayer(createPlayerDto);
            return Ok(createPlayerDto);
        }

        [HttpGet("{id}")]
        public ActionResult GetPlayer(Guid id)
        {
            var player = _playerService.GetPlayer(id);
            return Ok(player);
        }
    }
}
