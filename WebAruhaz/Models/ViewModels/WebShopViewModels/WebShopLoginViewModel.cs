//-----------------------------------------------------------------------
// <copyright file="WebShopLoginViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.WebShopViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="WebShopLoginViewModel" />
    /// </summary>
    public class WebShopLoginViewModel
    {
        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether RememberMe
        /// </summary>
        [Display(Name = "Emlékezz rám")]
        public bool RememberMe { get; set; }
    }
}
