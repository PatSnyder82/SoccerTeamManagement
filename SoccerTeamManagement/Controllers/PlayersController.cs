using AutoMapper;
using Core.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerTeamManagement.Data.DTOs.Joins;
using SoccerTeamManagement.Data.DTOs.People;
using SoccerTeamManagement.Data.Models.Joins;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<PlayerDetailsDTO>> GetPlayer(int id)
        {
            try
            {
                var player = await _context.Players.AsNoTracking()
                    .Include(x => x.Country)
                    .Include(x => x.Phone)
                    .Include(x => x.PlayerPositions).ThenInclude(x => x.Position).ThenInclude(x => x.PositionCategory)
                    .Include(x => x.TeamPlayers).ThenInclude(x => x.Team)
                    .Include(x => x.Address).ThenInclude(x => x.State)
                    .Include(x => x.Address).ThenInclude(x => x.Country).FirstOrDefaultAsync(x => x.Id == id);

                if (player == null)
                    return NotFound();

                var dto = _mapper.Map<Player, PlayerDetailsDTO>(player);

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
        public async Task<IActionResult> PutPlayer(PlayerDetailsDTO dto)
        {
            try
            {
                Player player = await _context.Set<Player>().AsNoTracking()
                                        .Include(x => x.PlayerPositions).AsNoTracking()
                                        .Include(x => x.TeamPlayers).AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Id == dto.Id);

                player = _mapper.Map<PlayerDetailsDTO, Player>(dto);

                //UpdatePlayerPositions(ref player, dto);
                //UpdateTeamPlayers(ref player, dto);
                //UpdatePlayerPositions(ref player, dto);
                //UpdateTeamPlayers(ref player, dto);

                //player.PlayerPositions.Clear();

                //IList<PlayerPosition> playerPositions = await _context.PlayerPositions
                //                                                .Where(x => x.PlayerId == dto.Id).ToListAsync();

                //if (playerPositions?.Count > 0)
                //{
                //    foreach (var playerPosition in playerPositions)
                //    {
                //        _context.Remove(playerPosition);
                //    }
                //}

                //if (dto.PlayerPositions.Count > 0)
                //{
                //    foreach (var playerPosition in dto.PlayerPositions)
                //    {
                //        _context.Set<PlayerPosition>().Add(_mapper.Map<PlayerPositionDTO, PlayerPosition>(playerPosition));
                //    }
                //}

                //player.TeamPlayers.Clear();

                //IList<TeamPlayer> teamPlayers = _context.TeamPlayers
                //                                    .Where(x => x.PlayerId == dto.Id).ToList();

                //if (teamPlayers?.Count > 0)
                //{
                //    foreach (var teamPlayer in teamPlayers)
                //    {
                //        _context.Remove(teamPlayer);
                //    }
                //}

                //if (dto.TeamPlayers.Count > 0)
                //{
                //    foreach (var teamPlayer in dto.TeamPlayers)
                //    {
                //        _context.Set<TeamPlayer>().Add(_mapper.Map<TeamPlayerDTO, TeamPlayer>(teamPlayer));
                //    }
                //}

                _context.Entry(player).State = EntityState.Modified;

                _context.Players.Update(player);

                await _context.SaveChangesAsync();

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

        private void UpdatePlayerPositions(ref Player player, PlayerDetailsDTO dto)
        {
            player.PlayerPositions.Clear();
            IList<PlayerPosition> playerPositions = _context.Set<PlayerPosition>().AsNoTracking().Where(x => x.PlayerId == dto.Id).ToList();

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
                    _context.Set<PlayerPosition>().Add(_mapper.Map<PlayerPositionDTO, PlayerPosition>(playerPosition));
                }
            }

            _context.SaveChanges();
        }

        private void UpdateTeamPlayers(ref Player player, PlayerDetailsDTO dto)
        {
            player.TeamPlayers.Clear();
            IList<TeamPlayer> teamPlayers = _context.Set<TeamPlayer>().AsNoTracking()
                                                .Where(x => x.PlayerId == dto.Id).ToList();

            if (teamPlayers?.Count > 0)
            {
                foreach (var teamPlayer in teamPlayers)
                {
                    _context.Remove(teamPlayer);
                }
            }

            if (dto.TeamPlayers.Count > 0)
            {
                foreach (var teamPlayer in dto.TeamPlayers)
                {
                    _context.Set<TeamPlayer>().Add(_mapper.Map<TeamPlayerDTO, TeamPlayer>(teamPlayer));
                }
            }

            _context.SaveChanges();
        }
    }
}