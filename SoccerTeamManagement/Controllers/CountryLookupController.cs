using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerTeamManagement.Data;
using SoccerTeamManagement.Data.Models;
using WorldCities.Data;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryLookupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CountryLookupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CountriesLookup
        [HttpGet]
        public async Task<ActionResult<ApiResult<CountryLookup>>> GetCountryLookup(int pageIndex = 0, int pageSize = 10, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            return await ApiResult<CountryLookup>.CreateAsync(_context.CountryLookup, pageIndex, pageSize, sortColumn, sortOrder, filterColumn, filterQuery);
        }

        // GET: api/CountriesLookup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryLookup>> GetCountryLookup(int id)
        {
            var countryLookup = await _context.CountryLookup.FindAsync(id);

            if (countryLookup == null)
            {
                return NotFound();
            }

            return countryLookup;
        }

        // PUT: api/CountriesLookup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryLookup(int id, CountryLookup countryLookup)
        {
            if (id != countryLookup.Id)
            {
                return BadRequest();
            }

            _context.Entry(countryLookup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryLookupExists(id))
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

        // POST: api/CountriesLookup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryLookup>> PostCountryLookup(CountryLookup countryLookup)
        {
            _context.CountryLookup.Add(countryLookup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryLookup", new { id = countryLookup.Id }, countryLookup);
        }

        // DELETE: api/CountriesLookup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryLookup(int id)
        {
            var countryLookup = await _context.CountryLookup.FindAsync(id);
            if (countryLookup == null)
            {
                return NotFound();
            }

            _context.CountryLookup.Remove(countryLookup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryLookupExists(int id)
        {
            return _context.CountryLookup.Any(e => e.Id == id);
        }
    }
}