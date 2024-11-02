using TeamService.Models.Dto;
using TeamService.Models.Entities;

namespace TeamService.Services.Contracts
{
    public interface ITeamsService
    {
        Task<TeamDto> CreateTeam(TeamRequestDto teamDto);
        Task<IEnumerable<TeamDto>> GetTeams();
        Task<TeamDto> GetTeam(int teamId);
    }
}
