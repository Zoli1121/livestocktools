//-----------------------------------------------------------------------
// <copyright file="WareHouseService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Services.WarehouseServices
{
    using System.Collections.Generic;
    using WebAruhaz.Data;
    using WebAruhaz.Models.WarehouseModels;
    using WebAruhaz.Services.WarehouseServices.Interfaces;

    /// <summary>
    /// Defines the <see cref="WareHouseService" />
    /// </summary>
    public class WareHouseService : IWareHouseService
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="WareHouseService"/> class.
        /// </summary>
        /// <param name="appDbContext">The appDbContext<see cref="ApplicationDbContext"/></param>
        public WareHouseService(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        /// <summary>
        /// Gets the WareHouses
        /// </summary>
        public IEnumerable<WareHouse> WareHouses
        {
            get { return context.WareHouses; }
        }
    }
}
