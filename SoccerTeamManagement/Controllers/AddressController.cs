using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldCities.Data;
using Core.Models;
using Infrastructure;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AddressController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Address
        [HttpGet]
        public async Task<ActionResult<Address>> GetAddress()
        {
            try
            {
                var entities = await _context.Addresses.AsNoTracking().ToListAsync();

                return Ok(entities);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Address/TableData
        [HttpGet]
        [Route("TableData")]
        public async Task<ActionResult<TableData<Address>>> TableData(int pageIndex = 0, int pageSize = 10, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            try
            {
                var entities = await TableData<Address>.CreateAsync(_context.Addresses.AsNoTracking(), pageIndex, pageSize, sortColumn, sortOrder, filterColumn, filterQuery);

                return Ok(entities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            try
            {
                var address = await _context.Addresses.AsNoTracking().Include(x => x.Country).Include(x => x.State).FirstOrDefaultAsync(x => x.Id == id);

                if (address == null)
                    return NotFound();

                return Ok(address);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Address/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public async Task<IActionResult> PutAddress(Address address)
        {
            try
            {
                if (!_context.Addresses.AsNoTracking().Any(x => x.Id == address.Id))
                    return NoContent();

                var entity = _context.Addresses.Update(address);

                await _context.SaveChangesAsync();

                address = await _context.Addresses.AsNoTracking().Include(x => x.Country).Include(x => x.State).FirstOrDefaultAsync(x => x.Id == address.Id);

                return Ok(address);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Address
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            try
            {
                var result = _context.Addresses.Add(address);

                await _context.SaveChangesAsync();

                return Ok(result.Entity.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/Address/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            try
            {
                var address = await _context.Addresses.FindAsync(id);

                if (address == null)
                    return NotFound();

                _context.Addresses.Remove(address);

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