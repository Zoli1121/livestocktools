//-----------------------------------------------------------------------
// <copyright file="ExternalLoginsViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.ManageViewModels
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    
    /// <summary>
    /// Defines the <see cref="ExternalLoginsViewModel" />
    /// </summary>
    public class ExternalLoginsViewModel
    {
        /// <summary>
        /// Gets or sets the CurrentLogins
        /// </summary>
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        /// <summary>
        /// Gets or sets the OtherLogins
        /// </summary>
        public IList<AuthenticationScheme> OtherLogins { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether ShowRemoveButton
        /// </summary>
        public bool ShowRemoveButton { get; set; }

        /// <summary>
        /// Gets or sets the StatusMessage
        /// </summary>
        public string StatusMessage { get; set; }
    }
}
