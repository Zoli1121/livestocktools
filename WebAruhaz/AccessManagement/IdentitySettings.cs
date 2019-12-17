//-----------------------------------------------------------------------
// <copyright file="IdentitySettings.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.AccessManagement
{
    /// <summary>
    /// Defines the <see cref="IdentitySettings" />
    /// </summary>
    public class IdentitySettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether PasswordDigit
        /// </summary>
        public bool PasswordDigit { get; set; }

        /// <summary>
        /// Gets or sets the PasswordLength
        /// </summary>
        public int PasswordLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether PasswordNonAlphanumeric
        /// </summary>
        public bool PasswordNonAlphanumeric { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether PasswordUppercase
        /// </summary>
        public bool PasswordUppercase { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether PasswordLowercase
        /// </summary>
        public bool PasswordLowercase { get; set; }

        /// <summary>
        /// Gets or sets the PasswordChars
        /// </summary>
        public int PasswordChars { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether CookieHttpOnly
        /// </summary>
        public bool CookieHttpOnly { get; set; }

        /// <summary>
        /// Gets or sets the CookieExpiration
        /// </summary>
        public double CookieExpiration { get; set; }

        /// <summary>
        /// Gets or sets the LoginPath
        /// </summary>
        public string LoginPath { get; set; }

        /// <summary>
        /// Gets or sets the LogoutPath
        /// </summary>
        public string LogoutPath { get; set; }

        /// <summary>
        /// Gets or sets the AccessDeniedPath
        /// </summary>
        public string AccessDeniedPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SlidingExpiration
        /// </summary>
        public bool SlidingExpiration { get; set; }

        /// <summary>
        /// Gets or sets the LockoutTimeSpanInMinutes
        /// </summary>
        public double LockoutTimeSpanInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the MaxFailedAccessAttempts
        /// </summary>
        public int MaxFailedAccessAttempts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether AllowedForNewUsers
        /// </summary>
        public bool AllowedForNewUsers { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether UserUniqueEmail
        /// </summary>
        public bool UserUniqueEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SignInConfirmedEmail
        /// </summary>
        public bool SignInConfirmedEmail { get; set; }
    }
}
