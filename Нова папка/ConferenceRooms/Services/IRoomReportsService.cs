using ConferenceRooms.Contracts;
using ConferenceRooms.Services.Results;

namespace ConferenceRooms.Services;

public interface IRoomReportsService
{
    OperationResult<IReadOnlyCollection<RoomUtilizationReportDto>> GetRoomUtilizationReport(DateTime from, DateTime to);
}
