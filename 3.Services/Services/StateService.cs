using Core.Models.Lookups;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class StateService : LookupServiceBase<State>, IStateService
    {
        #region Constructor

        public StateService(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<State>> GetByCountryId(int countryId)
        {
            try
            {
                var entity = await _set.Where(x => x.CountryId == countryId).ToListAsync();

                if (entity != null)
                    return entity;

                return null;
            }
            catch (Exception exception)
            {
                LogError(exception, "GetByCountryId");
                return null;
            }
        }

        #endregion Methods
    }
}