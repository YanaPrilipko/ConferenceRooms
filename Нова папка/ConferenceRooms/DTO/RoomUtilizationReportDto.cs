namespace ConferenceRooms.Contracts;

public class RoomUtilizationReportDto
{
    public Guid RoomId { get; set; }
    public string RoomName { get; set; }
    public int BookingCount { get; set; }
    public double BookedHours { get; set; }
    public double AvailableHours { get; set; }
    public double UtilizationPercent { get; set; }
}
