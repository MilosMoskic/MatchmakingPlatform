using AutoMapper;
using MatchmakingPlatform.Application.Exceptions;
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

        public PlayerDetails CreatePlayer(CreatePlayerDto createPlayerDto)
        {
            var mappedPlayer = _mapper.Map<Player>(createPlayerDto);

            if (_playerRepository.PlayerExists(mappedPlayer.Nickname) != null)
            {
                throw new ConfictException("Player with that Nickname already exists.");
            }

            mappedPlayer.Wins = 0;
            mappedPlayer.Losses = 0;
            mappedPlayer.Elo = 0;
            mappedPlayer.HoursPlayed = 0;
            mappedPlayer.Team = null;
            mappedPlayer.RatingAdjustment = null;

            _playerRepository.CreatePlayer(mappedPlayer);

            var addedPlayer = _mapper.Map<PlayerDetails>(mappedPlayer);

            return addedPlayer;
        }

        public PlayerDetails GetPlayer(Guid id)
        {
            var player = _playerRepository.GetPlayer(id);

            if (player == null)
            {
                throw new NotFoundException("Player with this id doesn't exist");
            }

            var mappedPlayer = _mapper.Map<PlayerDetails>(player);

            return mappedPlayer;
        }
    }
}
