//-----------------------------------------------------------------------
// <copyright file="RackService.cs" company="SzzEV">
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
    /// Defines the <see cref="RackService" />
    /// </summary>
    public class RackService : IRackService
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RackService"/> class.
        /// </summary>
        /// <param name="appDbContext">The appDbContext<see cref="ApplicationDbContext"/></param>
        public RackService(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        /// <summary>
        /// Gets the Racks
        /// </summary>
        public IEnumerable<Rack> Racks
        {
            get { return context.Racks; }
        }
    }
}
