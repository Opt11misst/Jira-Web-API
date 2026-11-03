namespace Api.Models;

public class Booking
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ClassroomId { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsMaintenance { get; set; } = false;
}
