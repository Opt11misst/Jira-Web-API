using Microsoft.AspNetCore.Mvc;
using Xunit;
using Api.Controllers;
using Api.Models;

namespace Tests;

public class UsersControllerTests
{
    [Fact]
    public async Task Get_ReturnsOkResult()
    {
        // Arrange - ініціалізуємо контролер
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
        // Arrange - ініціалізуємо контролер
        var controller = new UsersController();

        // Act - викликаємо метод Delete
        var result = controller.Delete(1);

        // Assert - перевіряємо, що результат є типом NoContentResult (статус 204)
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Post_ReturnsCreatedResult_AndUserAppearsInList()
    {
        // Arrange - ініціалізуємо контролер і нового користувача
        var controller = new UsersController();
        var newUser = new User { Id = 100, Name = "New User" };

        // Act - створюємо користувача
        var result = await controller.Post(newUser);

        // Assert - перевіряємо статус 201 Created і правильні дані
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnedUser = Assert.IsType<User>(createdResult.Value);
        Assert.Equal("New User", returnedUser.Name);

        // Перевіряємо, що користувач з'явився у списку
        var getResult = await controller.Get();
        var okResult = Assert.IsType<OkObjectResult>(getResult);
        var users = Assert.IsAssignableFrom<IEnumerable<User>>(okResult.Value);
        Assert.Contains(users, u => u.Id == 100);
    }
}