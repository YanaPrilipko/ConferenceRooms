using ConferenceRooms.Models;

namespace ConferenceRooms.Services;

public readonly record struct BookingCost(decimal RentalCost, decimal ServicesCost, decimal TotalCost);

public class BookingCostCalculator : IBookingCostCalculator
{
    public BookingCost Calculate(decimal baseHourlyRate, DateTime start, DateTime end, IEnumerable<ServiceOption> selectedServices)
    {
        var rentalCost = CalculateRentalCost(baseHourlyRate, start, end);
        var servicesCost = selectedServices.Sum(s => s.Price);
        var totalCost = rentalCost + servicesCost;

        return new BookingCost(
            decimal.Round(rentalCost, 2),
            decimal.Round(servicesCost, 2),
            decimal.Round(totalCost, 2));
    }

    private decimal CalculateRentalCost(decimal baseHourlyRate, DateTime start, DateTime end)
    {
        var total = 0m;
        var current = start;

        while (current < end)
        {
            var next = current.AddMinutes(30);
            if (next > end)
            {
                next = end;
            }

            var hours = (decimal)(next - current).TotalHours;
            var multiplier = GetMultiplier(current.TimeOfDay);
            total += baseHourlyRate * multiplier * hours;
            current = next;
        }

        return total;
    }

    private decimal GetMultiplier(TimeSpan time)
    {
        if (time >= new TimeSpan(18, 0, 0) && time < new TimeSpan(23, 0, 0))
        {
            return 0.8m;
        }

        if (time >= new TimeSpan(6, 0, 0) && time < new TimeSpan(9, 0, 0))
        {
            return 0.9m;
        }

        if (time >= new TimeSpan(12, 0, 0) && time < new TimeSpan(14, 0, 0))
        {
            return 1.15m;
        }

        return 1.0m;
    }
}
