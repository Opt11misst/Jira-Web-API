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
    [Fact]
    public async Task Get_ByCapacity_ReturnsFilteredClassrooms()
    {
        // Arrange - створюємо контролер і додаємо дві різні аудиторії
        var controller = new ClassroomsController();
        await controller.Post(new Classroom { Number = "101", Capacity = 30, HasProjector = false });
        await controller.Post(new Classroom { Number = "102", Capacity = 50, HasProjector = true });

        // Act - намагаємося отримати аудиторії з місткістю від 40 місць
        // (Visual Studio підкреслить цей рядок червоним, бо методу Get з таким параметром ще немає)
        var result = await controller.Get(minCapacity: 40);

        // Assert - перевіряємо, що повернувся статус 200 OK і правильний список
        var okResult = Assert.IsType<OkObjectResult>(result);
        var classrooms = Assert.IsAssignableFrom<System.Collections.Generic.IEnumerable<Classroom>>(okResult.Value);

        // Переконуємося, що велика аудиторія є в списку, а малої - немає
        Assert.Contains(classrooms, c => c.Number == "102");
        Assert.DoesNotContain(classrooms, c => c.Number == "101");
    }
}
