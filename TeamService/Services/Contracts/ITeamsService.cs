using TeamService.Models.Dto;
using TeamService.Models.Entities;

namespace TeamService.Services.Contracts
{
    public interface ITeamsService
    {
        Task<TeamDto> CreateTeam(TeamRequestDto teamDto);
        Task<IEnumerable<TeamDto>> GetTeams();
        Task<TeamDto> GetTeam(int teamId);
        Task<TeamDto> UpdateTeam(int teamId, TeamRequestDto teamRequestDto);
        Task DeleteTeam(int teamId);
    }
}
