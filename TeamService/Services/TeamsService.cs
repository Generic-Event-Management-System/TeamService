using TeamService.Persistence;
using TeamService.Services.Contracts;

namespace TeamService.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly TeamDbContext _dbContext;

        public TeamsService(TeamDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
