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

        public void UpdatePlayerStats(Guid playerId, int hoursPlayed, int wins, int losses, double newElo)
        {
            var player = _playerRepository.GetPlayer(playerId);
            player.Elo = Convert.ToInt32(newElo);
            player.Wins = wins;
            player.Losses = losses;
            player.HoursPlayed += hoursPlayed;

            player.RatingAdjustment = CalculateRatingAdjustment(player.HoursPlayed);

            _playerRepository.UpdatePlayer(player);
        }

        public double CalculateNewElo(int currentElo, int opponentElo, double score, int hoursPlayed)
        {
            double expected = 1 / (1 + Math.Pow(10, (opponentElo - currentElo) / 400.0));

            int K = CalculateRatingAdjustment(hoursPlayed);

            return currentElo + K * (score - expected);
        }

        public int CalculateRatingAdjustment(int hoursPlayed)
        {
            if (hoursPlayed < 500) return 50;
            if (hoursPlayed < 1000) return 40;
            if (hoursPlayed < 3000) return 30;
            if (hoursPlayed < 5000) return 20;
            return 10;
        }
    }
}
