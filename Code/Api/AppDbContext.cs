using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Classroom> Classrooms => Set<Classroom>();
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Classroom>().HasKey(c => c.Number);

        // Id задаёт клиент (как было в ЛР2), поэтому без автогенерации
        b.Entity<User>().Property(u => u.Id).ValueGeneratedNever();
        b.Entity<User>().HasData(
            new User { Id = 1, Name = "Test User 1" },
            new User { Id = 2, Name = "Test User 2" },
            new User { Id = 3, Name = "Test User 3" });
    }
}