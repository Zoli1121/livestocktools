//-----------------------------------------------------------------------
// <copyright file="ExternalLoginViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="ExternalLoginViewModel" />
    /// </summary>
    public class ExternalLoginViewModel
    {
        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
