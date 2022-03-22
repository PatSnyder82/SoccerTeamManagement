using AutoMapper;
using Core.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldCities.Data;

namespace SoccerLeagueManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public LeagueController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/League
        [HttpGet]
        public async Task<ActionResult<League>> GetLeagues()
        {
            try
            {
                var entities = await _context.Leagues.OrderBy(x => x.Name).AsNoTracking().ToListAsync();

                return Ok(entities);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/League/TableData
        [HttpGet]
        [Route("TableData")]
        public async Task<ActionResult<TableData<League>>> GetLeague(int pageIndex = 0, int pageSize = 10, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            try
            {
                var entities = await TableData<League>.CreateAsync(_context.Leagues.AsNoTracking(), pageIndex, pageSize, sortColumn, sortOrder, filterColumn, filterQuery);
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<League>> GetLeague(int id)
        {
            var league = await _context.Leagues.FindAsync(id);

            if (league == null)
            {
                return NotFound();
            }

            return league;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeague(int id, League league)
        {
            if (id != league.Id)
            {
                return BadRequest();
            }

            _context.Entry(league).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueExists(id))
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
        public async Task<ActionResult<League>> PostLeague(League league)
        {
            _context.Leagues.Add(league);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeague", new { id = league.Id }, league);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeague(int id)
        {
            var league = await _context.Leagues.FindAsync(id);
            if (league == null)
            {
                return NotFound();
            }

            _context.Leagues.Remove(league);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeagueExists(int id)
        {
            return _context.Leagues.Any(e => e.Id == id);
        }
    }
}