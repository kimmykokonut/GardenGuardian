namespace GardenApi.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string NameTag { get; set; }
        public List<SeedTag> SeedTags { get; }
    }
}
