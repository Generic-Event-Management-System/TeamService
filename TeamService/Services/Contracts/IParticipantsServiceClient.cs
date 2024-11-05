namespace TeamService.Services.Contracts
{
    public interface IParticipantsServiceClient
    {
        Task<bool> CheckParticipantsExists(ICollection<int> participantIds);
    }
}
