using ConferenceRooms.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRooms.Data;

public class ConferenceRoomsDbContext(DbContextOptions<ConferenceRoomsDbContext> options) : DbContext(options)
{
    public DbSet<ConferenceRoom> Rooms => Set<ConferenceRoom>();
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConferenceRoom>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Name).HasMaxLength(100).IsRequired();
            entity.Property(r => r.BaseHourlyRate).HasPrecision(18, 2);

            entity.OwnsMany(r => r.Services, navigationBuilder =>
            {
                navigationBuilder.ToTable("RoomServices");
                navigationBuilder.WithOwner().HasForeignKey("RoomId");
                navigationBuilder.Property(s => s.Id).ValueGeneratedNever();
                navigationBuilder.HasKey("RoomId", nameof(ServiceOption.Id));
                navigationBuilder.Property(s => s.Name).HasMaxLength(60).IsRequired();
                navigationBuilder.Property(s => s.Price).HasPrecision(18, 2);
            });
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.RoomName).HasMaxLength(100).IsRequired();
            entity.Property(b => b.RentalCost).HasPrecision(18, 2);
            entity.Property(b => b.ServicesCost).HasPrecision(18, 2);
            entity.Property(b => b.TotalCost).HasPrecision(18, 2);

            entity.HasOne<ConferenceRoom>()
                .WithMany()
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.OwnsMany(b => b.Services, navigationBuilder =>
            {
                navigationBuilder.ToTable("BookingServices");
                navigationBuilder.WithOwner().HasForeignKey("BookingId");
                navigationBuilder.Property(s => s.Id).ValueGeneratedNever();
                navigationBuilder.HasKey("BookingId", nameof(ServiceOption.Id));
                navigationBuilder.Property(s => s.Name).HasMaxLength(60).IsRequired();
                navigationBuilder.Property(s => s.Price).HasPrecision(18, 2);
            });
        });

        base.OnModelCreating(modelBuilder);
    }
}
