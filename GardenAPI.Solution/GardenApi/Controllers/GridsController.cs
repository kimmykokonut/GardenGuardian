using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using GardenApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GardenApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GridsController : Controller
  {
    private readonly GardenApiContext _db;
    public GridsController(GardenApiContext db)
    {
      _db = db;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Grid>> GetGrids() //retrieves all grid objects;
    {
      return _db.Grids.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Grid> GetGrid(int id)
    {
      var grid = _db.Grids
          .Include(g => g.GridSeeds)
          .ThenInclude(gs => gs.Seed)
          .FirstOrDefault(g => g.GridId == id);

      if (grid == null)
      {
        return NotFound();
      }
      return grid;
    }
    [HttpPost]
    public ActionResult<Grid> PostGrid(Grid grid)
    {
      _db.Grids.Add(grid);
      _db.SaveChanges();

      return CreatedAtAction(nameof(GetGrid), new { id = grid.GridId }, grid);
    }

    [HttpPut("{id}")] 
    public IActionResult PutGrid(int id, Grid grid) // check id, determine result;
    {
      if (id != grid.GridId)
      {
        return BadRequest();
      }

      _db.Entry(grid).State = EntityState.Modified;

      try
      {
        _db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!GridExists(id))
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

    [HttpDelete("{id}")]
    public ActionResult<Grid> DeleteGrid(int id)
    {
      var grid = _db.Grids.Find(id);
      if(grid == null)
      {
        return NotFound();
      }

      _db.Grids.Remove(grid);
      _db.SaveChanges();

      return grid;
    }

    private bool GridExists(int id)
    {
      return _db.Grids.Any(e => e.GridId == id);
    }
  }
}