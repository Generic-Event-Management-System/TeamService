using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeamService.ExceptionHandling;
using TeamService.Models.Dto;
using TeamService.Models.Entities;
using TeamService.Persistence;
using TeamService.Services.Contracts;

namespace TeamService.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly TeamDbContext _dbContext;
        private readonly IMapper _mapper;

        public TeamsService(TeamDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Team> CreateTeam(TeamDto teamDto)
        {
            var team = _mapper.Map<Team>(teamDto);

            await _dbContext.Teams.AddAsync(team);
            await _dbContext.SaveChangesAsync();

            return team;
        }

        public async Task<IEnumerable<TeamDto>> GetTeams()
        {
            var teams = await _dbContext.Teams.Include(t => t.Participants).ToListAsync();
            return _mapper.Map<IEnumerable<TeamDto>>(teams);
        }

        public async Task<TeamDto> GetTeam(int teamId)
        {
            var team = await GetTeamOrThrowNotFoundException(teamId);

            return _mapper.Map<TeamDto>(team);
        }

        private async Task<Team> GetTeamOrThrowNotFoundException(int teamId)
        {
            var team = await _dbContext.Teams.FirstOrDefaultAsync(t => t.Id == teamId);

            if (team == null)
                throw new NotFoundException("Team not found.");

            return team;
        }
    }
}
