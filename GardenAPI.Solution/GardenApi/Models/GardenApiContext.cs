using Microsoft.EntityFrameworkCore;

namespace GardenApi.Models
{
  public class GardenApiContext : DbContext
  {
    public DbSet<Garden> Gardens { get; set; }
    public DbSet<Grid> Grids { get; set; }
    public DbSet<Seed> Seeds { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<GridSeed> GridSeeds { get; set; }
    public DbSet<SeedTag> SeedTags { get; set; }

    public GardenApiContext(DbContextOptions<GardenApiContext> options) : base(options)
    {
    }
  }
}