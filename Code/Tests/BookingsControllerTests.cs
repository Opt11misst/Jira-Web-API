using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Api.Controllers; // Знімеш коментар на етапі Green
using Api.Models;      // Знімеш коментар на етапі Green

namespace Tests;

public class BookingsControllerTests
{
    [Fact]
    public async Task CreateBooking_ReturnsCreatedResult_WhenTimeIsFree()
    {
        // Arrange - створюємо контролер і тестове бронювання на 1 годину
        var controller = new BookingsController();
        var newBooking = new Booking
        {
            ClassroomId = "101",
            StartTime = DateTime.Now.AddHours(1),
            EndTime = DateTime.Now.AddHours(2)
        };

        // Act - намагаємося створити бронювання
        var result = await controller.Post(newBooking);

        // Assert - перевіряємо, що бронювання успішне (201 Created)
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnedBooking = Assert.IsType<Booking>(createdResult.Value);
        Assert.Equal("101", returnedBooking.ClassroomId);
    }
    [Fact]
    public async Task GetSchedule_ReturnsBookings_ForSpecificClassroom()
    {
        // Arrange - створюємо контролер
        var controller = new BookingsController();
        var roomId = "202b"; // Використовуємо унікальний номер, щоб тести не впливали один на одного
        var time = DateTime.Now.AddDays(1); // Беремо завтрашній день

        // Створюємо два успішних бронювання (без перетину) для цієї аудиторії
        await controller.Post(new Booking { ClassroomId = roomId, StartTime = time, EndTime = time.AddHours(1) });
        await controller.Post(new Booking { ClassroomId = roomId, StartTime = time.AddHours(2), EndTime = time.AddHours(3) });

        // Act - намагаємося отримати розклад для аудиторії 202b
        // (Visual Studio підкреслить Get червоним, бо цього методу ще немає)
        var result = await controller.Get(roomId);

        // Assert - перевіряємо, що повернувся 200 OK і список бронювань
        var okResult = Assert.IsType<OkObjectResult>(result);
        var schedule = Assert.IsAssignableFrom<System.Collections.Generic.IEnumerable<Booking>>(okResult.Value);

        // Перевіряємо, що наше бронювання є у розкладі
        Assert.Contains(schedule, b => b.ClassroomId == roomId);
    }
    [Fact]
    public async Task DeleteBooking_RemovesBooking_AndReturnsNoContent()
    {
        // Arrange - створюємо контролер і нове бронювання з ID
        var controller = new BookingsController();
        var bookingId = System.Guid.NewGuid(); // Генеруємо унікальний ідентифікатор

        var newBooking = new Booking
        {
            Id = bookingId, // Помилка компіляції: поля Id ще не існує
            ClassroomId = "303c",
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddHours(1)
        };
        await controller.Post(newBooking);

        // Act - намагаємося скасувати бронювання за його ID
        // (Методу Delete теж ще не існує)
        var result = await controller.Delete(bookingId);

        // Assert - REST стандарти вимагають повертати 204 No Content при успішному видаленні
        Assert.IsType<NoContentResult>(result);
    }
    [Fact]
    public async Task CreateMaintenanceBooking_ReturnsCreatedResult_AndHasMaintenanceFlag()
    {
        // Arrange - створюємо ремонтне бронювання на 3 дні
        var controller = new BookingsController();
        var maintenanceBooking = new Booking
        {
            ClassroomId = "505e",
            StartTime = DateTime.Now.AddDays(2),
            EndTime = DateTime.Now.AddDays(5),
            IsMaintenance = true // Помилка компіляції: поля ще не існує
        };

        // Act - створюємо запис про ремонт
        var result = await controller.Post(maintenanceBooking);

        // Assert - перевіряємо, що запис успішно створено і прапорець зберігся
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnedBooking = Assert.IsType<Booking>(createdResult.Value);

        Assert.True(returnedBooking.IsMaintenance);
    }
}