//-----------------------------------------------------------------------
// <copyright file="ChangePasswordViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="ChangePasswordViewModel" />
    /// </summary>
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// Gets or sets the OldPassword
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Jelenlegi jelszó")]
        public string OldPassword { get; set; }

        /// <summary>
        /// Gets or sets the NewPassword
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "A {0} legalább {2} és legfeljebb {1} karakter hosszú lehet.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Új jelszó")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the ConfirmPassword
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Új jelszó megerősítése")]
        [Compare("NewPassword", ErrorMessage = "A jelszó és a megerősítő jelszó nem egyezik.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the StatusMessage
        /// </summary>
        public string StatusMessage { get; set; }
    }
}
