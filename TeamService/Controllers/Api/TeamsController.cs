using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamService.Services.Contracts;

namespace TeamService.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamsService;

        public TeamsController(ITeamsService teamsService) 
        {
            _teamsService = teamsService;
        }
    }
}
