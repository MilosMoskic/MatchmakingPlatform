using AutoMapper;
using MatchmakingPlatform.Domain.Dto;
using MatchmakingPlatform.Domain.Models;

namespace MatchmakingPlatform.Domain.Profiles
{
    public class MatchmakingPlatformProfiles : Profile
    {
        public MatchmakingPlatformProfiles()
        {
            CreateMap<Player, CreatePlayerDto>().ReverseMap();
            CreateMap<Player, PlayerDetails>()
                .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.Team != null ? src.Team.Teamname : null))
                .ReverseMap();
            CreateMap<Player, PlayerDto>().ReverseMap();
            CreateMap<Team, TeamDetails>()
                .ForMember(dest => dest.Players, opt => opt.MapFrom(src => src.Players)).ReverseMap();
            CreateMap<CreateTeamDto, Team>()
                .ForMember(dest => dest.Players, opt => opt.Ignore()).ReverseMap();
            CreateMap<Match, CreateMatchDto>().ReverseMap();
        }
    }
}
