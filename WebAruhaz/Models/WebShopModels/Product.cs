//-----------------------------------------------------------------------
// <copyright file="Product.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.WebShopModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WebAruhaz.Models.WarehouseModels;

    /// <summary>
    /// Defines the <see cref="Product" />
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [Display(Name = "Megnevezés")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the PartNumber
        /// </summary>
        [Display(Name = "Cikkszám")]
        public string PartNumber { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        [Display(Name = "Leírás")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        [Display(Name = "Egységár")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the Image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the SmallImage
        /// </summary>
        public string SmallImage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether InStock
        /// </summary>
        public bool InStock { get; set; }

        /// <summary>
        /// Gets or sets the MadeTime
        /// </summary>
        [Display(Name = "Gyártás Dátuma")]
        public DateTime MadeTime { get; set; }

        /// <summary>
        /// Gets or sets the SerialNumber
        /// </summary>
        [Display(Name = "Gyáriszám")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the Batch
        /// </summary>
        [Display(Name = "Lejárat")]
        public DateTime Batch { get; set; }

        /// <summary>
        /// Gets or sets the Weight
        /// </summary>
        [Display(Name = "Saját tömeg")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets the QuantityUnit
        /// </summary>
        [Display(Name = "Mennyiség egység")]
        public string QuantityUnit { get; set; }

        /// <summary>
        /// Gets or sets the SubSubCategoryRefId
        /// </summary>
        [Display(Name = "Alkategória")]
        [ForeignKey("SubSubCategory")]
        public int SubSubCategoryRefId { get; set; }

        /// <summary>
        /// Gets or sets the SubSubCategory
        /// </summary>
        public Category SubSubCategory { get; set; }

        /// <summary>
        /// Gets or sets the CategoryRefId
        /// </summary>
        [Display(Name = "Főágazat")]
        public int CategoryRefId { get; set; }

        /// <summary>
        /// Gets or sets the SubCategoryRefId
        /// </summary>
        [Display(Name = "Kategória")]
        public int SubCategoryRefId { get; set; }

        /// <summary>
        /// Gets or sets the WareHouseRefId
        /// </summary>
        [Display(Name = "Raktár")]
        [ForeignKey("WareHouse")]
        public int WareHouseRefId { get; set; }

        /// <summary>
        /// Gets or sets the Warehouse
        /// </summary>
        public WareHouse Warehouse { get; set; }

        /// <summary>
        /// Gets or sets the RackRefId
        /// </summary>
        [Display(Name = "Tárhely")]
        [ForeignKey("Rack")]
        public int RackRefId { get; set; }

        /// <summary>
        /// Gets or sets the Rack
        /// </summary>
        public Rack Rack { get; set; }
    }
}
