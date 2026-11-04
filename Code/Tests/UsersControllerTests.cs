using Microsoft.AspNetCore.Mvc;
using Xunit;
using Api.Controllers;

namespace Tests;

public class UsersControllerTests
{
    [Fact]
    public async Task Get_ReturnsOkResult()
    {
        // Arrange - ініціалізуємо контролер (якого ще не існує)
        var controller = new UsersController();

        // Act - викликаємо метод Get
        var result = await controller.Get();

        // Assert - перевіряємо, що результат є типом OkObjectResult (статус 200)
        Assert.IsType<OkObjectResult>(result);
    }
    // Copilot, сгенерируй HttpDelete метод Delete, который принимает int id и возвращает NoContent()

    [Fact]
    public void Delete_ReturnsNoContentResult()
    {
        // Arrange - ініціалізуємо контролер (якого ще не існує)
        var controller = new UsersController();

        // Act - викликаємо метод Delete
        var result = controller.Delete(1);

        // Assert - перевіряємо, що результат є типом NoContentResult (статус 204)
        Assert.IsType<NoContentResult>(result);
    }
}
