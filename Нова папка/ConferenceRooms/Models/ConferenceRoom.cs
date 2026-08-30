namespace ConferenceRooms.Models;

public class ConferenceRoom
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Capacity { get; set; }
    public decimal BaseHourlyRate { get; set; }
    public List<ServiceOption> Services { get; set; } = [];
}
