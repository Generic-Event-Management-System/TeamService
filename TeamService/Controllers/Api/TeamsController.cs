using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamService.Models.Dto;
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

        [HttpPost]
        public async Task<IActionResult> CreateTeam(TeamDto teamDto)
        {
            return Ok( await _teamsService.CreateTeam(teamDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            return Ok( await _teamsService.GetTeams());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            return Ok( await _teamsService.GetTeam(id));
        }
    }
}
