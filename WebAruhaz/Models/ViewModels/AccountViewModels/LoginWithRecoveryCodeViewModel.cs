//-----------------------------------------------------------------------
// <copyright file="LoginWithRecoveryCodeViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="LoginWithRecoveryCodeViewModel" />
    /// </summary>
    public class LoginWithRecoveryCodeViewModel
    {
        /// <summary>
        /// Gets or sets the RecoveryCode
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Helyreállító kód")]
        public string RecoveryCode { get; set; }
    }
}
