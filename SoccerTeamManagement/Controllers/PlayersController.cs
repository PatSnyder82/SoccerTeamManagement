using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerTeamManagement.Data;
using SoccerTeamManagement.Data.DTOs.People;
using SoccerTeamManagement.Data.Models.People;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldCities.Data;
using SoccerTeamManagement.Data.Models.Joins;
using SoccerTeamManagement.Data.DTOs.Lookups;
using System.Collections.Generic;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public PlayersController(ApplicationDbContext context, IMapper mapper) //
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<ActionResult<PlayerFlatDTO>> GetPlayer(int id)
        {
            try
            {
                var player = await _context.Players.AsNoTracking()
                    .Include(x => x.Country)
                    .Include(x => x.Phone)
                    .Include(x => x.PlayerPositions).ThenInclude(x => x.Position)
                    .Include(x => x.Address).ThenInclude(x => x.State)
                    .Include(x => x.Address).ThenInclude(x => x.Country).FirstOrDefaultAsync(x => x.Id == id);

                if (player == null)
                    return NotFound();

                var dto = _mapper.Map<PlayerFlatDTO>(player);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public async Task<IActionResult> PutPlayer(PlayerFlatDTO dto)
        {
            try
            {
                Player player = await _context.Set<Player>().AsNoTracking().Include(x => x.PlayerPositions).AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);

                //if (player != null)
                //{
                //    _context.Entry(player).State = EntityState.Detached;
                //}

                player = _mapper.Map<PlayerFlatDTO, Player>(dto);

                player.PlayerPositions.Clear();
                IList<PlayerPosition> playerPositions = await _context.Set<PlayerPosition>().Where(x => x.PlayerId == dto.Id).ToListAsync();

                if (playerPositions?.Count > 0)
                {
                    foreach (var playerPosition in playerPositions)
                    {
                        _context.Remove(playerPosition);
                    }
                }

                if (dto.PlayerPositions.Count > 0)
                {
                    foreach (var playerPosition in dto.PlayerPositions)
                    {
                        //player.PlayerPositions.Add(_mapper.Map<PlayerPositionFlatDTO, PlayerPosition>(playerPosition));
                        _context.Set<PlayerPosition>().Add(_mapper.Map<PlayerPositionFlatDTO, PlayerPosition>(playerPosition));
                    }
                }

                _context.Entry(player).State = EntityState.Modified;

                _context.Players.Update(player);

                await _context.SaveChangesAsync();
                /*
                Player player = await _context.Players.Include(x => x.PlayerPositions).FirstOrDefaultAsync(x => x.Id == dto.Id);

                if (player != null)
                {
                    player = _mapper.Map<PlayerFlatDTO, Player>(dto);

                    player.PlayerPositions.Clear();

                    if (dto.PlayerPositions.Count > 0)
                    {
                        foreach (var playerPosition in dto.PlayerPositions)
                        {
                            player.PlayerPositions.Add(_mapper.Map<PlayerPositionFlatDTO, PlayerPosition>(playerPosition));
                        }
                    }

                    _context.Players.Update(player);

                    await _context.SaveChangesAsync();

                    return Ok();
                }
                */
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<int>> PostPlayer(Player player)
        {
            try
            {
                var result = _context.Players.Add(player);

                await _context.SaveChangesAsync();

                return Ok(result.Entity.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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