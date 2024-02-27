using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenApi.Models;
using System.Linq;

namespace GardenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly GardenApiContext _db;

        public TagsController(GardenApiContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> Get(string nametag)
        {
            var query = _db.Tags.AsQueryable();

            if (nametag != null)
            {
                query = query.Where(entry => entry.NameTag == nametag);
                
            }
            return  await query.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(int id)
        {
            Tag thisTag = await _db.Tags
            .Include(tag => tag.SeedTags)
            .ThenInclude(join => join.Seed)
            .FirstOrDefaultAsync(tag => tag.TagId == id);
            if (thisTag == null)
            {
            return NotFound();
            }
            return thisTag;
        }

//create tag
        [HttpPost]
        public async Task<ActionResult<Tag>> Post(Tag tag)
        {
            _db.Tags.Add(tag);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTag), new { id = tag.TagId }, tag);
        }


//update/edit tag
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Tag tag)
        {
            if (id != tag.TagId)
            {
                return BadRequest();
            }
            _db.Tags.Update(tag);
            try 
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
            if (!TagExists(id))
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
    
    private bool TagExists(int id)
    {
        return _db.Tags.Any(e => e.TagId == id);
    }

//delete tag
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
        Tag thisTag = await _db.Tags.FindAsync(id);
            if (thisTag == null)
            {
                return NotFound();
            }

            _db.Tags.Remove(thisTag);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> AddTags(int id, SeedDto seedDto)
        {
            // Check if the provided seed id exists
            var existingSeed = await _db.Seeds.FindAsync(id);

            if (existingSeed == null)
            {
                return NotFound(); // Seed with the given id not found
            }

            // Iterate through the list of TagIds and create SeedTag entities
            foreach (var tagId in seedDto.TagIds)
            {
                // Create a new SeedTag entity and establish the relationship
                var seedTag = new SeedTag
                {
                    SeedId = id,     // Use the provided seed id
                    TagId = tagId    // Use the current tag id from the list
                };

                try
                {
                    _db.SeedTags.Add(seedTag);
                }
                catch (Exception ex)
                {
                    // Handle exception
                    return StatusCode(500, $"Error adding tag to seed: {ex.Message}");
                }
            }

            try
            {
                await _db.SaveChangesAsync();
                return NoContent(); // Successfully added the tag relationships to the seed
            }
            catch (DbUpdateException ex)
            {
                // Handle exception
                return StatusCode(500, $"Error saving changes: {ex.Message}");
            }
        }
        // //PATCH api/tags/5 same as add seed to tag (would delete then just be a patch to change the seed object to and empty object?)
        // [HttpPatch("{id}")]
        // public async Task<IActionResult> AddSeed(int id, SeedTag seedTag)
        // {
        // if (id != seedTag.TagId)
        // {
        //     return BadRequest();
        // }
        // _db.SeedTags.Add(seedTag);
        // await _db.SaveChangesAsync();
        // return NoContent();
        // }
    }
}