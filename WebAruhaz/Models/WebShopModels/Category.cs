//-----------------------------------------------------------------------
// <copyright file="Category.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.WebShopModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Category" />
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the CategoryId
        /// </summary>
        [Key]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the CategoryName
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the ParentId
        /// </summary>
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the Parent
        /// </summary>
        public Category Parent { get; set; }

        /// <summary>
        /// Gets or sets the Childs
        /// </summary>
        public IEnumerable<Category> Childs { get; set; }
    }
}
