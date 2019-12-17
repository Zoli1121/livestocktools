//-----------------------------------------------------------------------
// <copyright file="IRackService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Services.WarehouseServices.Interfaces
{
    using System.Collections.Generic;
    using WebAruhaz.Models.WarehouseModels;

    /// <summary>
    /// Defines the <see cref="IRackService" />
    /// </summary>
    public interface IRackService
    {
        /// <summary>
        /// Gets the Racks
        /// </summary>
        IEnumerable<Rack> Racks { get; }
    }
}
