using TeamService.Models.Entities;

namespace TeamService.Models.Dto
{
    public class TeamDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ICollection<int> Participants { get; set; }
    }
}
