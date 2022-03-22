using AutoMapper;
using Core.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerTeamManagement.Data.Models.Joins;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldCities.Data;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamPlayerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public TeamPlayerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TeamPlayer
        [HttpGet]
        public async Task<ActionResult<TeamPlayer>> GetTeamPlayer()
        {
            try
            {
                var entities = await _context.TeamPlayers.AsNoTracking().ToListAsync();

                return Ok(entities);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/TeamPlayer/TableData
        [HttpGet]
        [Route("TableData")]
        public async Task<ActionResult<TableData<TeamPlayer>>> TableData(int pageIndex = 0, int pageSize = 10, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            try
            {
                var entities = await TableData<TeamPlayer>.CreateAsync(_context.TeamPlayers.AsNoTracking(), pageIndex, pageSize, sortColumn, sortOrder, filterColumn, filterQuery);

                return Ok(entities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> PutTeamPlayer(TeamPlayerDTO teamPlayer)
        {
            try
            {
                if (!_context.TeamPlayers.AsNoTracking().Any(x => x.PlayerId == teamPlayer.PlayerId && x.TeamId == teamPlayer.TeamId))
                    return NoContent();

                var entity = _context.TeamPlayers.Update(_mapper.Map<TeamPlayerDTO, TeamPlayer>(teamPlayer));

                await _context.SaveChangesAsync();

                teamPlayer = _mapper.Map<TeamPlayer, TeamPlayerDTO>(await _context.TeamPlayers.AsNoTracking().FirstOrDefaultAsync(x => x.PlayerId == teamPlayer.PlayerId && x.TeamId == teamPlayer.TeamId));

                return Ok(teamPlayer);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/TeamPlayer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamPlayer>> PostTeamPlayer(TeamPlayer teamPlayer)
        {
            try
            {
                var result = _context.TeamPlayers.Add(teamPlayer);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}