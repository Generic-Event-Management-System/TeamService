namespace TeamService.Models.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ICollection<TeamParticipant> Participants { get; set; }
    }
}
