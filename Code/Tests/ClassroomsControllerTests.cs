using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Api.Controllers;
using Api.Models;

namespace Tests;

public class ClassroomsControllerTests
{
    [Fact]
    public async Task CreateClassroom_ReturnsCreatedResult_WhenDataIsValid()
    {
        // Arrange - ініціалізуємо контролер та тестову аудиторію
        var controller = new ClassroomsController();
        var newClassroom = new Classroom { Number = "404a", Capacity = 50, HasProjector = true };

        // Act - викликаємо асинхронний метод Post
        var result = await controller.Post(newClassroom);

        // Assert - перевіряємо статус 201 Created та правильність даних
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnedClassroom = Assert.IsType<Classroom>(createdResult.Value);
        Assert.Equal("404a", returnedClassroom.Number);
    }
}