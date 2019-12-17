//-----------------------------------------------------------------------
// <copyright file="WareHouse.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.WarehouseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="WareHouse" />
    /// </summary>
    public class WareHouse
    {
        /// <summary>
        /// Gets or sets the WareHouseId
        /// </summary>
        [Key]
        public int WareHouseId { get; set; }

        /// <summary>
        /// Gets or sets the WareHouseName
        /// </summary>
        [Display(Name = "Raktárnév")]
        public string WareHouseName { get; set; }

        /// <summary>
        /// Gets or sets the Racks
        /// </summary>
        public List<Rack> Racks { get; set; }
    }
}
