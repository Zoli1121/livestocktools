//-----------------------------------------------------------------------
// <copyright file="IWareHouseService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Services.WarehouseServices.Interfaces
{
    using System.Collections.Generic;
    using WebAruhaz.Models.WarehouseModels;

    /// <summary>
    /// Defines the <see cref="IWareHouseService" />
    /// </summary>
    public interface IWareHouseService
    {
        /// <summary>
        /// Gets the WareHouses
        /// </summary>
        IEnumerable<WareHouse> WareHouses { get; }
    }
}
