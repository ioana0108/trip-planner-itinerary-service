using Microsoft.EntityFrameworkCore;
using TripPlanner.ItineraryService.Models;

namespace TripPlanner.ItineraryService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ItineraryItem> ItineraryItems => Set<ItineraryItem>();
}