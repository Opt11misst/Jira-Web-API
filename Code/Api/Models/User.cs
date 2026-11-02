namespace Api.Models;

public record User
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}
