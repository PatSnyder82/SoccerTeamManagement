using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerTeamManagement.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCities.Data;
using Core.Models;
using Infrastructure;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public TeamController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Team
        [HttpGet]
        public async Task<ActionResult<Team>> GetTeams()
        {
            try
            {
                var entities = await _context.Teams.OrderBy(x => x.Name).AsNoTracking().ToListAsync();

                return Ok(entities);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Team/TableData
        [HttpGet]
        [Route("TableData")]
        public async Task<ActionResult<TableData<Team>>> GetTeam(int pageIndex = 0, int pageSize = 10, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            try
            {
                var entities = await TableData<Team>.CreateAsync(_context.Teams.AsNoTracking(), pageIndex, pageSize, sortColumn, sortOrder, filterColumn, filterQuery);
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("getteamsbyleague/{leagueId:int}")]
        public async Task<ActionResult<TeamDetailsDTO>> GetTeamsByLeague(int leagueId)
        {
            try
            {
                var entities = await _context.LeagueTeams.AsNoTracking()
                    .Where(x => x.LeagueId == leagueId)
                    .Select(x => x.Team)
                    .OrderBy(x => x.Name)
                    .ToListAsync();

                if (entities == null)
                    return NoContent();

                var dto = _mapper.Map<ICollection<Team>, ICollection<TeamDetailsDTO>>(entities);

                return Ok(dto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getteamsbyclub/{clubId:int}")]
        public async Task<ActionResult<TeamDetailsDTO>> GetTeamsByClub(int clubId)
        {
            try
            {
                var entities = await _context.Teams.AsNoTracking()
                    .Where(x => x.ClubId == clubId)
                    .OrderBy(x => x.Name)
                    .ToListAsync();

                if (entities == null)
                    return NoContent();

                var dto = _mapper.Map<ICollection<Team>, ICollection<TeamDetailsDTO>>(entities);

                return Ok(dto);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}