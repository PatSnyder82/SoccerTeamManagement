using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerTeamManagement.Data;
using SoccerTeamManagement.Data.Models;
using SoccerTeamManagement.Data.Models.People;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldCities.Data;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PositionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Position
        [HttpGet]
        public async Task<ActionResult<Position>> GetPosition()
        {
            try
            {
                var entities = await _context.Positions.AsNoTracking().ToListAsync();

                return Ok(entities);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Position/TableData
        [HttpGet]
        [Route("TableData")]
        public async Task<ActionResult<TableData<Position>>> TableData(int pageIndex = 0, int pageSize = 10, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            try
            {
                var entities = await TableData<Position>.CreateAsync(_context.Positions.AsNoTracking(), pageIndex, pageSize, sortColumn, sortOrder, filterColumn, filterQuery);

                return Ok(entities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Position/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetPosition(int id)
        {
            try
            {
                var position = await _context.Positions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (position == null)
                    return NotFound();

                return Ok(position);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Position/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public async Task<IActionResult> PutPosition(Position position)
        {
            try
            {
                if (!_context.Positions.AsNoTracking().Any(x => x.Id == position.Id))
                    return NoContent();

                var entity = _context.Positions.Update(position);

                await _context.SaveChangesAsync();

                position = await _context.Positions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == position.Id);

                return Ok(position);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Position
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Position>> PostPosition(Position position)
        {
            try
            {
                var result = _context.Positions.Add(position);

                await _context.SaveChangesAsync();

                return Ok(result.Entity.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/Position/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            try
            {
                var position = await _context.Positions.FindAsync(id);

                if (position == null)
                    return NotFound();

                _context.Positions.Remove(position);

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