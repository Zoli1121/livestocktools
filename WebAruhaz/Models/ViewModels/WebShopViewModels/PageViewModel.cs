//-----------------------------------------------------------------------
// <copyright file="PageViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.WebShopViewModels
{
    using System;

    /// <summary>
    /// Defines the <see cref="PageViewModel" />
    /// </summary>
    public class PageViewModel
    {
        /// <summary>
        /// Gets or sets the TotalItems
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the ItemsPerPage
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Gets or sets the CurrentPage
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets the Pages
        /// </summary>
        public int Pages
        {
            get { return (int)Math.Ceiling((decimal)this.TotalItems / this.ItemsPerPage); }
        }
    }
}
