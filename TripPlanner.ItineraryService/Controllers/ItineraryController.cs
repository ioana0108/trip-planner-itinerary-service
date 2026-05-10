using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripPlanner.ItineraryService.Data;
using TripPlanner.ItineraryService.Dtos;
using TripPlanner.ItineraryService.Models;

namespace TripPlanner.ItineraryService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItineraryController : ControllerBase
{
    private readonly AppDbContext _context;

    public ItineraryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Itinerary service works!");
    }

    [HttpPost]
    public async Task<IActionResult> CreateItineraryItem(CreateItineraryItemRequest request)
    {
        var item = new ItineraryItem
        {
            TripId = request.TripId,
            DayNumber = request.DayNumber,
            ActivityTitle = request.ActivityTitle,
            Location = request.Location,
            Time = request.Time,
            Notes = request.Notes
        };

        _context.ItineraryItems.Add(item);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Itinerary item created successfully",
            item
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetItineraryItems()
    {
        var items = await _context.ItineraryItems.ToListAsync();

        return Ok(items);
    }

    [HttpGet("trip/{tripId}")]
    public async Task<IActionResult> GetItineraryItemsByTrip(int tripId)
    {
        var items = await _context.ItineraryItems
            .Where(i => i.TripId == tripId)
            .ToListAsync();

        return Ok(items);
    }
}