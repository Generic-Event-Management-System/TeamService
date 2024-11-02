using AutoMapper;
using TeamService.Models.Dto;
using TeamService.Models.Entities;

namespace TeamService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamDto>()
                .ForMember(dest => dest.Participants,
                    opt => opt.MapFrom(src => src.Participants.Select(p => p.ParticipantId).ToList()));

            CreateMap<TeamDto, Team>()
                .ForMember(dest => dest.Participants,
                    opt => opt.MapFrom((src, dest) => src.Participants
                        .Select(id => new TeamParticipant { ParticipantId = id }).ToList()));

            CreateMap<Team, TeamRequestDto>()
               .ForMember(dest => dest.Participants,
                   opt => opt.MapFrom(src => src.Participants.Select(p => p.ParticipantId).ToList()));

            CreateMap<TeamRequestDto, Team>()
                .ForMember(dest => dest.Participants,
                    opt => opt.MapFrom((src, dest) => src.Participants
                        .Select(id => new TeamParticipant { ParticipantId = id }).ToList()));
        }
    }
}
