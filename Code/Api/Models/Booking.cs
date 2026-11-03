namespace Api.Models;

public class Booking
{
    public string ClassroomId { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
