using AutoMapper;
using MatchmakingPlatform.Application.Interface;
using MatchmakingPlatform.Domain.Dto;
using MatchmakingPlatform.Domain.Interfaces;
using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public Player CreatePlayer(CreatePlayerDto createPlayerDto)
        {

            var mappedPlayer = _mapper.Map<Player>(createPlayerDto);

            mappedPlayer.Wins = 0;
            mappedPlayer.Losses = 0;
            mappedPlayer.Elo = 0;
            mappedPlayer.HoursPlayed = 0;
            mappedPlayer.Team = null;
            mappedPlayer.RatingAdjustment = null;

            _playerRepository.CreatePlayer(mappedPlayer);

            return mappedPlayer;
        }
    }
}
