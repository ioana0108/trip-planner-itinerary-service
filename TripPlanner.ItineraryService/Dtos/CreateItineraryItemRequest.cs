namespace TripPlanner.ItineraryService.Dtos;

public class CreateItineraryItemRequest
{
    public int TripId { get; set; }

    public int DayNumber { get; set; }

    public string ActivityTitle { get; set; } = string.Empty;

    public string? Location { get; set; }

    public string? Time { get; set; }

    public string? Notes { get; set; }
}