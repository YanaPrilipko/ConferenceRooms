using System.ComponentModel.DataAnnotations;

namespace ConferenceRooms.Contracts;

public class ServiceOptionDto
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 2)]
    public string Name { get; set; }

    public decimal Price { get; set; }
}
