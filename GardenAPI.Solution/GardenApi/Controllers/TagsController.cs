using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenApi.Models;
using System.Linq;

namespace GardenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly GardenApiContext _db;

        public TagController(GardenApiContext db)
        {
            _db = db;
        }

//seeds that have the tag
        [HttpGet("{id}/Seeds")]
        public ActionResult GetSeedsForTag(int id)
        {
            var tag = _db.Tags
                .Include(t => t.SeedTags)
                .ThenInclude(st => st.Seed)
                .FirstOrDefault(t => t.TagId == id);

            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag.SeedTags.Select(st => st.Seed));
        }
//attach tag to seed
        [HttpPost("{id}/AttachSeed")]
        public ActionResult AttachTagFromSeed(int id, int seedId)
        {
            var tag = _db.Tags.Include(t => t.SeedTags).FirstOrDefault(t => t.TagId == id);
            var seed = _db.Seeds.Find(seedId);

            if (tag == null || seed == null)
            {
                return NotFound();
            }

            var seedTag = new SeedTag { TagId = id, SeedId = seedId };
            tag.SeedTags.Add(seedTag);
            _db.SaveChanges();

            return Ok();
        }
//detach tag to seed
        [HttpPost("{id}/DetachSeed")]
        public ActionResult DetachTagFromSeed(int id, int seedId)
        {
            var seedTag = _db.SeedTags.FirstOrDefault(st => st.TagId == id && st.SeedId == seedId);

            if (seedTag == null)
            {
                return NotFound();
            }

            _db.SeedTags.Remove(seedTag);
            _db.SaveChanges();

            return Ok();
        }
//create tag
        [HttpPost("Create")]
        public ActionResult<Tag> CreateTag(Tag tag)
        {
            _db.Tags.Add(tag);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetSeedsForTag), new { id = tag.TagId }, tag);
        }
//update/edit tag
        [HttpPut("{id}/Update")]
        public IActionResult UpdateTag(int id, Tag tag)
        {
            if (id != tag.TagId)
            {
                return BadRequest();
            }

            _db.Entry(tag).State = EntityState.Modified;
            _db.SaveChanges();

            return NoContent();
        }
//delete tag
        [HttpDelete("{id}/Delete")]
        public IActionResult DeleteTag(int id)
        {
            var tag = _db.Tags.Find(id);

            if (tag == null)
            {
                return NotFound();
            }

            _db.Tags.Remove(tag);
            _db.SaveChanges();

            return NoContent();
        }
    }
}