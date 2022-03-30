using Core.Models;
using Core.Models.Lookups;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AddressService : EntityServiceBase<Address>, IAddressService
    {
        #region Constructor

        public AddressService(ApplicationDbContext context, ILogger logger)
            : base(context, logger)
        {
        }

        #endregion Constructor

        #region Methods

        public override async Task<Address> GetById(int id)
        {
            try
            {
                if (id < 1)
                    return null;

                return await _set.Where(x => x.Id == id).AsNoTracking().Include(x => x.State).FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                LogError(exception, "GetById");
                return null;
            }
        }

        #endregion Methods
    }
}