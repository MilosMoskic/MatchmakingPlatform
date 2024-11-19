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
        }
    }
}
