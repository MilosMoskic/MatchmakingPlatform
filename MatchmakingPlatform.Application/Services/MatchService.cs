using AutoMapper;
using MatchmakingPlatform.Application.Exceptions;
using MatchmakingPlatform.Application.Interface;
using MatchmakingPlatform.Domain.Dto;
using MatchmakingPlatform.Domain.Interfaces;
using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Application.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public MatchService(IMatchRepository matchRepository, ITeamRepository teamRepository, IPlayerService playerService, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _teamRepository = teamRepository;
            _playerService = playerService;
            _mapper = mapper;
        }

        public Match CreateMatch(CreateMatchDto createMatchDto)
        {
            if (createMatchDto.Duration <= 0)
            {
                throw new BadRequestException("Duration cannot be eaqual to or under 0");
            }

            if (_teamRepository.GetTeam(createMatchDto.Team1Id) == null)
            {
                throw new NotFoundException($"Team with {createMatchDto.Team1Id} doesn't exist.");
            }

            if (_teamRepository.GetTeam(createMatchDto.Team2Id) == null)
            {
                throw new NotFoundException($"Team with {createMatchDto.Team2Id} doesn't exist.");
            }

            var mappedMatch = _mapper.Map<Match>(createMatchDto);

            _matchRepository.CreateMatch(mappedMatch);

            foreach (var player in mappedMatch.Team1.Players)
            {
                double score = createMatchDto.WinningTeamId == mappedMatch.Team1.Id ? 1 : (createMatchDto.WinningTeamId == null ? 0.5 : 0);
                var opponentTeam = mappedMatch.Team2.Players;
                int opponentElo = (int)Math.Round(opponentTeam.Select(p => p.Elo).Average());
                double newElo = _playerService.CalculateNewElo(player.Elo, opponentElo, score, createMatchDto.Duration);
                _playerService.UpdatePlayerStats(player.Id, createMatchDto.Duration, score == 1 ? 1 : 0, score == 0 ? 1 : 0, newElo);
            }

            foreach (var player in mappedMatch.Team2.Players)
            {
                double score = createMatchDto.WinningTeamId == mappedMatch.Team2.Id ? 1 : (createMatchDto.WinningTeamId == null ? 0.5 : 0);
                var opponentTeam = mappedMatch.Team1.Players;
                int opponentElo = (int)Math.Round(opponentTeam.Select(p => p.Elo).Average());
                double newElo = _playerService.CalculateNewElo(player.Elo, opponentElo, score, createMatchDto.Duration);
                _playerService.UpdatePlayerStats(player.Id, createMatchDto.Duration, score == 1 ? 1 : 0, score == 0 ? 1 : 0, newElo);
            }

            return mappedMatch;
        }
    }
}
