using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerTeamManagement.Data;
using SoccerTeamManagement.Data.Models.People;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldCities.Data;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<Player>> GetPlayers()
        {
            try
            {
                var entities = await _context.Players.AsNoTracking().ToListAsync();

                return Ok(entities);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Players/TableData
        [HttpGet]
        [Route("TableData")]
        public async Task<ActionResult<TableData<Player>>> TableData(int pageIndex = 0, int pageSize = 10, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            try
            {
                var entities = await TableData<Player>.CreateAsync(_context.Players.AsNoTracking().Include(x => x.Country).Include(x => x.Phone).Include(x => x.Address), pageIndex, pageSize, sortColumn, sortOrder, filterColumn, filterQuery);

                return Ok(entities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            try
            {
                var player = await _context.Players.AsNoTracking().Include(x => x.Country).Include(x => x.Phone).Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);

                if (player == null)
                    return NotFound();

                return Ok(player);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public async Task<IActionResult> PutPlayer(Player player)
        {
            try
            {
                if (!_context.Players.AsNoTracking().Any(x => x.Id == player.Id))
                    return NoContent();

                var entity = _context.Players.Update(player);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            try
            {
                var entity = _context.Players.Add(player);
                await _context.SaveChangesAsync();

                return CreatedAtAction("PostPlayer", entity);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            try
            {
                var player = await _context.Players.FindAsync(id);

                if (player == null)
                    return NotFound();

                _context.Players.Remove(player);

                await _context.SaveChangesAsync();

                return Accepted(id);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}