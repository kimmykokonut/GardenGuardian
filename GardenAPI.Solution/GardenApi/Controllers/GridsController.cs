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
    public ActionResult<IEnumerable<Grid>> GetGrids()
    {
      return _db.Grids.ToList();
    }
  }
}