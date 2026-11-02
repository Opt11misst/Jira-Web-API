// Copilot, створи публічний клас Classroom з властивостями Number (string), Capacity (int) та HasProjector (bool)

namespace Api.Models;

public class Classroom
{
    public string Number { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public bool HasProjector { get; set; }
}
