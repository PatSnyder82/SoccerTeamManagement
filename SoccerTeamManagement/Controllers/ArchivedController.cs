using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using SoccerTeamManagement.Data.DTOs;
using SoccerTeamManagement.Data.DTOs.People;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/*
 *
 * TODO: Delete
 * Saving this controller for the short term.  Once new SMControllerBase functionality is confirmed this will be deleted.
 *
 */

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivedController : EntityControllerBase<Player, PlayerListDTO, PlayerDetailsDTO>
    {
        #region Properties

        //private readonly IMapper _mapper;

        //private readonly ISoccerManagementService _service;

        #endregion Properties

        #region Constructor

        public ArchivedController(IMapper mapper, ISoccerManagementService service) : base(mapper, service, service.Players)
        {
        }

        #endregion Constructor

        //#region Endpoints

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<bool>> Delete(int id)
        //{
        //    var result = await _service.Players.Delete(id);

        //    if (result)
        //        result = await _service.SaveChangesAsync();

        //    if (result)
        //        return Ok(true);

        //    return BadRequest(false);
        //}

        //[HttpGet]
        //public async Task<ActionResult<PlayerDTO>> Get()
        //{
        //    var entities = await _service.Players.GetAll();

        //    if (entities != null && await _service.SaveChangesAsync())
        //        return Ok(_mapper.Map<IEnumerable<Player>, IEnumerable<PlayerDTO>>(entities));

        //    return NoContent();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<PlayerDetailsDTO>> Get(int id)
        //{
        //    var entity = await _service.Players.GetById(id);

        //    if (entity != null)
        //        return Ok(_mapper.Map<Player, PlayerDetailsDTO>(entity));

        //    return NoContent();
        //}

        //[HttpGet]
        //[Route("TableData")]
        //public async Task<ActionResult<TableDTO<PlayerDTO>>> TableData(int pageIndex = 0, int pageSize = 10, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        //{
        //    var entities = await _service.Players.GetTable(pageIndex, pageSize, sortColumn, sortOrder, filterColumn, filterQuery);

        //    if (entities != null)
        //        return Ok(_mapper.Map<Table<Player>, TableDTO<PlayerDTO>>(entities));

        //    return NoContent();
        //}

        //[HttpPost]
        //public async Task<ActionResult<PlayerDTO>> Post(PlayerDTO dto)
        //{
        //    var entity = _mapper.Map<PlayerDTO, Player>(dto);
        //    var result = await _service.Players.Create(entity);

        //    if (result)
        //        result = await _service.SaveChangesAsync();

        //    if (result)
        //        return CreatedAtAction("Get", new { id = entity.Id }, entity);

        //    return BadRequest();
        //}

        //[HttpPut]
        //public async Task<ActionResult<bool>> Put(PlayerDetailsDTO dto)
        //{
        //    if (dto.Id < 1)
        //        return BadRequest(false);

        //    var entity = _mapper.Map<PlayerDetailsDTO, Player>(dto);

        //    if (await _service.Players.Upsert(entity))
        //        if (await _service.SaveChangesAsync())
        //            return Ok(true);

        //    return BadRequest(false);
        //}

        //#endregion Endpoints

        private void UpdatePlayerPositions(ref Player player, PlayerDetailsDTO dto)
        {
            //player.PlayerPositions.Clear();
            //IList<PlayerPosition> playerPositions = _context.Set<PlayerPosition>().AsNoTracking().Where(x => x.PlayerId == dto.Id).ToList();

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

            //_context.SaveChanges();
        }

        private void UpdateTeamPlayers(ref Player player, PlayerDetailsDTO dto)
        {
            //player.TeamPlayers.Clear();
            //IList<TeamPlayer> teamPlayers = _context.Set<TeamPlayer>().AsNoTracking()
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

            //_context.SaveChanges();
        }
    }
}