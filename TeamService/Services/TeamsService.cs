﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SharedUtilities.CustomExceptions;
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
        private readonly IParticipantsServiceClient _participantsServiceClient;

        public TeamsService(TeamDbContext dbContext, IMapper mapper, IParticipantsServiceClient participantsServiceClient)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _participantsServiceClient = participantsServiceClient;
        }

        public async Task<TeamDto> CreateTeam(TeamRequestDto teamDto)
        {
            var areParticipantsValid = await _participantsServiceClient.CheckParticipantsExists(teamDto.Participants);

            if (areParticipantsValid)
            {
                var team = _mapper.Map<Team>(teamDto);

                await _dbContext.Teams.AddAsync(team);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<TeamDto>(team);
            }
            else
                throw new BadRequestException("One or more participant IDs are invalid");  
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

        public async Task<TeamDto> UpdateTeam(int teamId, TeamRequestDto teamRequestDto)
        {
            var areParticipantsValid = await _participantsServiceClient.CheckParticipantsExists(teamRequestDto.Participants);

            if (areParticipantsValid) 
            {
                var team = await GetTeamOrThrowNotFoundException(teamId);

                _mapper.Map(teamRequestDto, team);

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<TeamDto>(team);
            }
            else
                throw new BadRequestException("One or more participant IDs are invalid");
        }

        public async Task DeleteTeam(int teamId)
        {
            var team = await GetTeamOrThrowNotFoundException(teamId);

            _dbContext.Remove(team);

            await _dbContext.SaveChangesAsync();
        }

        private async Task<Team> GetTeamOrThrowNotFoundException(int teamId)
        {
            var team = await _dbContext.Teams.Include(t => t.Participants).FirstOrDefaultAsync(t => t.Id == teamId);

            if (team == null)
                throw new NotFoundException("Team not found.");

            return team;
        }
    }
}
