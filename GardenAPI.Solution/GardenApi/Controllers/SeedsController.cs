using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

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
  public async Task<ActionResult<IEnumerable<Seed>>> Get(string type, string name, string plantingDates, string status, string results, int yield)
  {
    IQueryable<Seed> q = _db.Seeds.AsQueryable();
    if (type != null)
    {
      q = q.Where(e => e.Type == type);
    }
    if (name != null)
    {
      q = q.Where(e => e.Name.Contains(name));
    }
    if (plantingDates != null)
    {
      q = q.Where(e => e.PlantingDates == plantingDates);
    }
    if (status != null)
    {
      q = q.Where(e => e.Status == status);
    }
    if (results != null)
    {
      q = q.Where(e => e.Results == results);
    }
    if (yield > 0)
    {
      q = q.Where(e => e.Yield == yield);
    }

    return await q.ToListAsync();
  }
  [HttpGet("{id}")]
  public async Task<ActionResult<Seed>> GetSeed(int id)
  {
    Seed foundSeed = await _db.Seeds
    // .Include(seed => seed.SeedTags)
    // .ThenInclude(seedTag => seedTag.Tag)
    // .FirstOrDefaultAsync(seed => seed.SeedId == id);
    .FindAsync(id);
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
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteSeed(int id)
  {
    Seed seedToDelete = await _db.Seeds.FindAsync(id);
    if (seedToDelete == null)
    {
      return NotFound();
    }
    _db.Seeds.Remove(seedToDelete);
    await _db.SaveChangesAsync();

    return NoContent();
  }

  [HttpPatch("{id}")]
  public async Task<IActionResult> AddTags(int id, SeedDto seedDto)
  {
    //creates a JoinEntity but SeedID is 0 every time and not updateing the JoinEntity table ("SeedTags")
    var existingSeed = await _db.Seeds.FindAsync(id);
    
    if (existingSeed == null)
    {
      return NotFound();
    }
    try
    {
      foreach (var tagId in seedDto.TagIds)
      {
        // Create a new SeedTag entity and establish the relationship
        var seedTag = new SeedTag
        {
          SeedId = id,
          TagId = tagId
        };
        
        _db.SeedTags.Add(seedTag);
      }
        
      
        await _db.SaveChangesAsync();
        return NoContent();
      }
      catch (DbUpdateException ex)
      {
        return StatusCode(500, $"Error saving changes: {ex.Message}");
      }
    }

  }
