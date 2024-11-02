namespace TeamService.Models.Entities
{
    public class TeamParticipant
    {
        public int Id { get; set; }
        public required int ParticipantId { get; set; }
        public required Team Team { get; set; }
    }
}
