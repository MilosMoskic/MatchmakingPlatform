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
            try
            {
                _playerService.CreatePlayer(createPlayerDto);
                return Ok(createPlayerDto);
            }
            catch (Exception ex)
            {
                return Conflict(new { Message = "Player with this username already exists." });
            }
        }
    }
}
