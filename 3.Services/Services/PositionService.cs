using Core.Models.Lookups;
using Infrastructure;
using Microsoft.Extensions.Logging;
using Services.Abstractions;

namespace Services.Services
{
    public class PositionService : LookupServiceBase<Position>, IPositionService
    {
        #region Constructor

        public PositionService(ApplicationDbContext context, ILogger logger)
            : base(context, logger)
        {
        }

        #endregion Constructor
    }
}