//-----------------------------------------------------------------------
// <copyright file="IndexViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="IndexViewModel" />
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Gets or sets the Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsEmailConfirmed
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the PhoneNumber
        /// </summary>
        [Phone]
        [Display(Name = "Telefonszám")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the StatusMessage
        /// </summary>
        public string StatusMessage { get; set; }
    }
}
