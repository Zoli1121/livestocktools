//-----------------------------------------------------------------------
// <copyright file="ResetPasswordViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="ResetPasswordViewModel" />
    /// </summary>
    public class ResetPasswordViewModel
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
        [StringLength(100, ErrorMessage = "A {0} legalább {2} és legfeljebb {1} karakter hosszú lehet.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the ConfirmPassword
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "A jelszó és a megerősítő jelszó nem egyezik.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the Code
        /// </summary>
        public string Code { get; set; }
    }
}
