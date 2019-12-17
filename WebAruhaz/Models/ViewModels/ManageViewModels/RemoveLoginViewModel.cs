//-----------------------------------------------------------------------
// <copyright file="RemoveLoginViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.ManageViewModels
{
    /// <summary>
    /// Defines the <see cref="RemoveLoginViewModel" />
    /// </summary>
    public class RemoveLoginViewModel
    {
        /// <summary>
        /// Gets or sets the LoginProvider
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the ProviderKey
        /// </summary>
        public string ProviderKey { get; set; }
    }
}
