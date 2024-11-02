using AutoMapper;
using TeamService.Models.Dto;
using TeamService.Models.Entities;

namespace TeamService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Team, TeamDto>();
            CreateMap<TeamDto, TeamDto>();
        }
    }
}
