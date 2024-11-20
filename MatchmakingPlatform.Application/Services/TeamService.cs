using AutoMapper;
using MatchmakingPlatform.Application.Exceptions;
using MatchmakingPlatform.Application.Interface;
using MatchmakingPlatform.Domain.Dto;
using MatchmakingPlatform.Domain.Interfaces;
using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper, IPlayerRepository playerRepository)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
            _mapper = mapper;
        }


        public TeamDetails CreateTeam(CreateTeamDto teamDto)
        {
            var players = new List<Player>();

            foreach (var id in teamDto.Players)
            {
                var player = _playerRepository.GetPlayer(id);
                if (player == null)
                {
                    throw new NotFoundException("Player not found.");
                }

                players.Add(player);
            }

            var mappedTeam = _mapper.Map<Team>(teamDto);

            if (_teamRepository.TeamExists(mappedTeam.Teamname) != null)
            {
                throw new ConfictException("Team with that Teamname already exists.");
            }

            mappedTeam.Players = players;

            if (mappedTeam.Players.Count != 5)
            {
                throw new BadRequestException("Team must have exactly 5 players.");
            }

            _teamRepository.CreateTeam(mappedTeam);

            var teamDetails = _mapper.Map<TeamDetails>(mappedTeam);

            return teamDetails;
        }
    }
}
