namespace ConferenceRooms.Models;

public class Booking
{
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    public required string RoomName { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public double DurationHours { get; set; }
    public List<ServiceOption> Services { get; set; } = [];
    public decimal RentalCost { get; set; }
    public decimal ServicesCost { get; set; }
    public decimal TotalCost { get; set; }
}
