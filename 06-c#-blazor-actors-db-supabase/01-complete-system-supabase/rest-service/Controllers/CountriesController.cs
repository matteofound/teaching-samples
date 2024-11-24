using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Supabase;

using ActorsRestService.Models;

namespace ActorssRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly Client _supabase;

        public CountriesController(Client supabase)
        {
            _supabase = supabase;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountry()
        {
            var response = await _supabase
                                    .From<Country>()
                                    .Get();
            return response.Models;
        }

        // GET: api/Countries/5
        [HttpGet("{code}")]
        public async Task<ActionResult<Country>> GetCountry(string code)
        {
            var response = await _supabase
                                    .From<Country>()
                                    .Where(c => c.CountryCode == code)
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


        // PUT: api/Countries/RU
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{code}")]
        public async Task<IActionResult> PutCountry(string code, Country newData)
        {
            if (code != newData.CountryCode)
            {
                return BadRequest();
            }
            Country oldItem = await _supabase
                            .From<Country>()
                            .Where(a => a.CountryCode == code)
                            .Single();
            if (oldItem is null)
            {
                return BadRequest();
            }
            oldItem.CountryCode = newData.CountryCode;
            oldItem.CountryName = newData.CountryName;
            oldItem.CreatedAt = newData.CreatedAt;
            await _supabase
                    .From<Country>()
                    .Update(oldItem);
            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            var ret = await _supabase
                .From<Country>()
                .Insert(country);
            string code = "";
            if ((ret is not null) && (ret.Model is not null))
                code = ret.Model.CountryCode;
            return CreatedAtAction("GetCountry", new { code = code }, country);
        }

        // DELETE: api/Countries/RU
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteCountry(string code)
        {
            var response = await _supabase
                                    .From<Country>()
                                    .Where(a => a.CountryCode == code)
                                    .Get();
            if (response == null)
            {
                return NotFound();
            }
            if (response.Model == null)
            {
                return NotFound();
            }
            await _supabase
                    .From<Country>()
                    .Where(x => x.CountryCode == code)
                    .Delete();
            return NoContent();
        }

    }
}
