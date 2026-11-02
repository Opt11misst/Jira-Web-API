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
}
