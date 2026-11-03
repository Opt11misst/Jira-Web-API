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
}