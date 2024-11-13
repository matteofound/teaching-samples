using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Supabase;

using ActorsRestService.Models;

namespace ActorsRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly Client _supabase;

        public ActorsController(Client supabase)
        {
            _supabase = supabase;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActor()
        {
            var response = await _supabase.From<Actor>()
                                        .Get();
            return response.Models;
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            var response = await _supabase.From<Actor>()
                                    .Where(a => a.ActorId == id)
                                    .Get();
            if (response == null)
            {
                return NotFound();
            }
            if (response.Model == null)
            {
                return NotFound();
            }
            return response.Model;
        }


        //// PUT: api/Actors/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutActor(long id, Actor actor)
        //{
        //    if (id != actor.Id)
        //    {
        //        return BadRequest();
        //    }

            
        //    _context.Entry(actor).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ActorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
            
        //    return NoContent();
        //}

        //// POST: api/Actors
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Actor>> PostActor(Actor actor)
        //{

        //    _context.Actor.Add(actor);
        //    await _context.SaveChangesAsync();
            
        //    return CreatedAtAction("GetActor", new { id = actor.Id }, actor);
        //}

        //// DELETE: api/Actors/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteActor(long id)
        //{
        //    var actor = await _context.Actor.FindAsync(id);
        //    if (actor == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Actor.Remove(actor);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ActorExists(long id)
        //{
        //    return _context.Actor.Any(e => e.Id == id);
        //}
    }
}
