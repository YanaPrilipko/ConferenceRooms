using ConferenceRooms.Models;

namespace ConferenceRooms.Services;

public interface IBookingCostCalculator
{
    BookingCost Calculate(decimal baseHourlyRate, DateTime start, DateTime end, IEnumerable<ServiceOption> selectedServices);
}
