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


}