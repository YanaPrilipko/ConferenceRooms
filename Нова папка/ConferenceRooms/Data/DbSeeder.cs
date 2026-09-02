using ConferenceRooms.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRooms.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(ConferenceRoomsDbContext dbContext)
    {
        if (await dbContext.Rooms.AnyAsync())
        {
            return;
        }

        var defaultServices = new List<ServiceOption>
        {
            new() { Id = Guid.NewGuid(), Name = "Проєктор", Price = 500 },
            new() { Id = Guid.NewGuid(), Name = "Wi-Fi", Price = 300 },
            new() { Id = Guid.NewGuid(), Name = "Звук", Price = 700 }
        };

        var rooms = new List<ConferenceRoom>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Зал A",
                Capacity = 50,
                BaseHourlyRate = 2000,
                Services = CopyServices(defaultServices)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Зал B",
                Capacity = 100,
                BaseHourlyRate = 3500,
                Services = CopyServices(defaultServices)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Зал C",
                Capacity = 30,
                BaseHourlyRate = 1500,
                Services = CopyServices(defaultServices)
            }
        };

        dbContext.Rooms.AddRange(rooms);
        await dbContext.SaveChangesAsync();
    }

    private static List<ServiceOption> CopyServices(IEnumerable<ServiceOption> services)
    {
        return services.Select(s => new ServiceOption
        {
            Id = Guid.NewGuid(),
            Name = s.Name,
            Price = s.Price
        }).ToList();
    }
}
