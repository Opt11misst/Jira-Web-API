using Microsoft.AspNetCore.Mvc;
using Xunit;
// using Api.Controllers; // Розкоментуєш на етапі Green
// using Api.Models;      // Розкоментуєш на етапі Green

namespace Tests;

public class ClassroomsControllerTests
{
    [Fact]
    public void CreateClassroom_ReturnsCreatedResult_WhenDataIsValid()
    {
        // Arrange - ініціалізуємо контролер та тестову аудиторію
        var controller = new ClassroomsController();
        var newClassroom = new Classroom { Number = "404a", Capacity = 50, HasProjector = true };

        // Act - викликаємо метод Post для створення
        var result = controller.Post(newClassroom);

        // Assert - перевіряємо, що повернувся статус 201 Created
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);

        // Перевіряємо, що API повернуло саме ту аудиторію, яку ми створили
        var returnedClassroom = Assert.IsType<Classroom>(createdResult.Value);
        Assert.Equal("404a", returnedClassroom.Number);
    }
}