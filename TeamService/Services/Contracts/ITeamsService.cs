using TeamService.Models.Dto;
using TeamService.Models.Entities;

namespace TeamService.Services.Contracts
{
    public interface ITeamsService
    {
        Task<Team> CreateTeam(TeamDto teamDto);
        Task<IEnumerable<TeamDto>> GetTeams();
        Task<TeamDto> GetTeam(int teamId);
    }
}
