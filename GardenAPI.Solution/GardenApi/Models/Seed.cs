using System.Collections.Generic;

namespace GardenApi.Models
{
    public class seed
    {
    public string Type {get; set;}
    public string Name {get; set;}
    public int Quantity {get; set;}
    public string Information {get; set;}
    public string PlantingDates {get; set;}
    public string DaysToGerminate {get; set;}
    public int DepthToSow {get; set;}
    public string SeedSpacing {get; set;}
    public string RowSpacing {get; set;}
    public string DaysToHarvest {get; set;}
    public string PhotoUrl {get; set;}
    public string Status {get; set;}
    public string Results {get; set;}
    public string Yield {get; set;}

    }
}