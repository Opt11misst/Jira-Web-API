using Microsoft.AspNetCore.Mvc;
using Xunit;
using Api.Controllers;

namespace Tests;

public class UsersControllerTests
{
    [Fact]
    public void Get_ReturnsOkResult()
    {
        // Arrange - ініціалізуємо контролер (якого ще не існує)
        var controller = new UsersController();

        // Act - викликаємо метод Get
        var result = controller.Get();

        // Assert - перевіряємо, що результат є типом OkObjectResult (статус 200)
        Assert.IsType<OkObjectResult>(result);
    }
}
