using Core.Models.Lookups;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldCities.Data;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/State
        [HttpGet]
        public async Task<ActionResult<State>> GetStates()
        {
            try
            {
                var entities = await _context.States.OrderBy(x => x.SortOrder).AsNoTracking().ToListAsync();

                return Ok(entities);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/State/TableData
        [HttpGet]
        [Route("TableData")]
        public async Task<ActionResult<TableData<State>>> GetState(int pageIndex = 0, int pageSize = 10, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            try
            {
                var entities = await TableData<State>.CreateAsync(_context.States.AsNoTracking(), pageIndex, pageSize, sortColumn, sortOrder, filterColumn, filterQuery);
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/GetStatesByCountry/5
        [HttpGet]
        [Route("getstatesbycountry/{countryId:int}")]
        public async Task<ActionResult<State>> GetStatesByCountry(int countryId)
        {
            try
            {
                var entities = await _context.States.AsNoTracking().Where(x => x.CountryId == countryId).ToListAsync();

                if (entities == null)
                    return NoContent();

                return Ok(entities);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetState(int id)
        {
            var state = await _context.States.FindAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            return state;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(int id, State state)
        {
            if (id != state.Id)
            {
                return BadRequest();
            }

            _context.Entry(state).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<State>> PostState(State state)
        {
            _context.States.Add(state);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetState", new { id = state.Id }, state);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            _context.States.Remove(state);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StateExists(int id)
        {
            return _context.States.Any(e => e.Id == id);
        }
    }
}