//-----------------------------------------------------------------------
// <copyright file="Rack.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.WarehouseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WebAruhaz.Models.WebShopModels;

    /// <summary>
    /// Defines the <see cref="Rack" />
    /// </summary>
    public class Rack
    {
        /// <summary>
        /// Gets or sets the RackCode
        /// </summary>
        [Key]
        public int RackCode { get; set; }

        /// <summary>
        /// Gets or sets the RackNumber
        /// </summary>
        [Display(Name = "tárolóhely kódszáma")]
        public string RackNumber { get; set; }

        /// <summary>
        /// Gets or sets the RackInformation
        /// </summary>
        [Display(Name = "tárolóhely információ")]
        public string RackInformation { get; set; }

        /// <summary>
        /// Gets or sets the WareHouseRefId
        /// </summary>
        [Display(Name = "Raktár")]
        [ForeignKey("WareHouse")]
        public int WareHouseRefId { get; set; }

        /// <summary>
        /// Gets or sets the WareHouse
        /// </summary>
        public WareHouse WareHouse { get; set; }

        /// <summary>
        /// Gets or sets the Products
        /// </summary>
        public List<Product> Products { get; set; }
    }
}
