using System.Collections.Generic;

namespace GardenApi.Models
{
  public class Grid
  {
    public int GridId { get; set; }
    public string LocationCode { get; set; }
    public int GardenId { get; set; }
    public Garden Garden { get; set; }
    public List<GridSeed> GridSeeds { get; }
  }
}