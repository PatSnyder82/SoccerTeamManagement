using Core.Models.Lookups;
using Infrastructure;
using Microsoft.Extensions.Logging;
using Services.Abstractions;

namespace Services.Services
{
    public class CountryService : LookupServiceBase<Country>, ICountryService
    {
        #region Constructor

        public CountryService(ApplicationDbContext context, ILogger logger)
            : base(context, logger)
        {
        }

        #endregion Constructor
    }
}