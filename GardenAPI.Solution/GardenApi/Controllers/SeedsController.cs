using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenApi.Models;

namespace GardenApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeedsController : ControllerBase
{
  private readonly GardenApiContext _db;

  public SeedsController(GardenApiContext db)
  {
    _db = db;
  }
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Seed>>> Get()
  {
    return await _db.Seeds.ToListAsync();
  }
  [HttpGet("{id}")]
  public async Task<ActionResult<Seed>> GetSeed(int id)
  {
    Seed foundSeed = await _db.Seeds.FindAsync(id);
    if (foundSeed == null)
    {
      return NotFound();
    }
    return foundSeed;
  }
  [HttpPost]
  public async Task<ActionResult<Seed>> Post(Seed seed)
  {
    _db.Seeds.Add(seed);
    await _db.SaveChangesAsync();
    return CreatedAtAction(nameof(GetSeed), new { id = seed.SeedId }, seed);
  }
  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, Seed seed)
  {
    if (id != seed.SeedId)
    {
      return BadRequest();
    }
    _db.Seeds.Update(seed);

    try 
    {
      await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!SeedExists(id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }
    return NoContent();
  }
  private bool SeedExists(int id)
  {
    return _db.Seeds.Any(e => e.SeedId == id);
  }


}