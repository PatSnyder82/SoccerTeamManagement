using AutoMapper;
using Core.Abstractions;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using SoccerTeamManagement.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Controllers
{
    public class EntityControllerBase<T, TList, TDetails> : ControllerBase
        where T : EntityBase where TList : ListBaseDTO where TDetails : DetailsBaseDTO
    {
        #region Properties

        protected readonly IMapper _mapper;

        protected readonly ISoccerManagementService _service;

        protected readonly IEntityServiceBase<T> _entityService;

        #endregion Properties

        #region Constructor

        public EntityControllerBase(IMapper mapper, ISoccerManagementService service, IEntityServiceBase<T> entityService)
        {
            _entityService = entityService;
            _mapper = mapper;
            _service = service;
        }

        #endregion Constructor

        #region Endpoints

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _entityService.Delete(id);

            if (result)
                result = await _service.SaveChangesAsync();

            if (result)
                return Ok(true);

            return BadRequest(false);
        }

        [HttpGet]
        public async Task<ActionResult<TList>> Get()
        {
            var entities = await _entityService.GetAll();

            if (entities != null && await _service.SaveChangesAsync())
                return Ok(_mapper.Map<IEnumerable<T>, IEnumerable<TList>>(entities));

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDetails>> Get(int id)
        {
            var entity = await _entityService.GetById(id);

            if (entity != null)
                return Ok(_mapper.Map<T, TDetails>(entity));

            return NoContent();
        }

        [HttpGet]
        [Route("TableData")]
        public async Task<ActionResult<TableDTO<TList>>> TableData(int pageIndex = 0, int pageSize = 10, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            var entities = await _entityService.GetTable(pageIndex, pageSize, sortColumn, sortOrder, filterColumn, filterQuery);

            if (entities != null)
                return Ok(_mapper.Map<Table<T>, TableDTO<TList>>(entities));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TDetails>> Post(TDetails dto)
        {
            var entity = _mapper.Map<TDetails, T>(dto);
            var result = await _entityService.Create(entity);

            if (result)
                result = await _service.SaveChangesAsync();

            if (result)
                return CreatedAtAction("Get", new { id = entity.Id }, entity);

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put(TDetails dto)
        {
            if (dto.Id < 1)
                return BadRequest(false);

            var entity = _mapper.Map<TDetails, T>(dto);

            if (await _entityService.Upsert(entity))
                if (await _service.SaveChangesAsync())
                    return Ok(true);

            return BadRequest(false);
        }

        #endregion Endpoints
    }
}