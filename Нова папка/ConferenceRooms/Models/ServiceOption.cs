namespace ConferenceRooms.Models;

public class ServiceOption
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
}
