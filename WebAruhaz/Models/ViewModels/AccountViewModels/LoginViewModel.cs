//-----------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="LoginViewModel" />
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        [Required]
        [Display(Name = "Felhasználó")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the ReturnUrl
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
