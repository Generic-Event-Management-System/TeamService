using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    }
}
