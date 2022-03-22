using AutoMapper;
using Core.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerTeamManagement.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCities.Data;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public ClubController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Club
        [HttpGet]
        public async Task<ActionResult<Club>> GetClubs()
        {
            try
            {
                var entities = await _context.Clubs.OrderBy(x => x.Name).AsNoTracking().ToListAsync();

                return Ok(entities);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Club/TableData
        [HttpGet]
        [Route("TableData")]
        public async Task<ActionResult<TableData<Club>>> GetClub(int pageIndex = 0, int pageSize = 10, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            try
            {
                var entities = await TableData<Club>.CreateAsync(_context.Clubs.AsNoTracking(), pageIndex, pageSize, sortColumn, sortOrder, filterColumn, filterQuery);
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/GetClubsByCountry/5
        [HttpGet]
        [Route("getclubsbyleague/{leagueId:int}")]
        public async Task<ActionResult<ClubDetailsDTO>> GetClubsByLeague(int leagueId)
        {
            try
            {
                var entities = await _context.ClubLeagues.AsNoTracking()
                    .Where(x => x.LeagueId == leagueId)
                    .Select(x => x.Club)
                    .OrderBy(x => x.Name)
                    .ToListAsync();

                if (entities == null)
                    return NoContent();

                var dto = _mapper.Map<ICollection<Club>, ICollection<ClubDetailsDTO>>(entities);

                return Ok(dto);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetClub(int id)
        {
            var club = await _context.Clubs.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            return club;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClub(int id, Club club)
        {
            if (id != club.Id)
            {
                return BadRequest();
            }

            _context.Entry(club).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(id))
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
        public async Task<ActionResult<Club>> PostClub(Club club)
        {
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClub", new { id = club.Id }, club);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }

            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClubExists(int id)
        {
            return _context.Clubs.Any(e => e.Id == id);
        }
    }
}