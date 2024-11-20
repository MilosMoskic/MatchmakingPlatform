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
            CreateMap<Player, PlayerDetails>().ReverseMap();
            CreateMap<Player, PlayerDto>().ReverseMap();
            CreateMap<Team, TeamDetails>()
                .ForMember(dest => dest.Players, opt => opt.MapFrom(src => src.Players)).ReverseMap();
            CreateMap<CreateTeamDto, Team>()
                .ForMember(dest => dest.Players, opt => opt.Ignore()).ReverseMap();
        }
    }
}
