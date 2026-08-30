using System.ComponentModel.DataAnnotations;

namespace ConferenceRooms.Contracts;

public class RoomDto
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } 

    public int Capacity { get; set; }

    public decimal BaseHourlyRate { get; set; }

    public List<ServiceOptionDto> Services { get; set; } = [];
}
