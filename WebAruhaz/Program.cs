//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// Defines the <see cref="Program" />
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Gets or sets the Host
        /// </summary>
        public static IWebHost Host { get; set; }

        /// <summary>
        /// The Main
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/></param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// The BuildWebHost
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/></param>
        /// <returns>The <see cref="IWebHost"/></returns>
        public static IWebHost BuildWebHost(string[] args)
        {
            Host = WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().UseDefaultServiceProvider(
                options => options.ValidateScopes = false).Build();
            return Host;
        }
    }
}
