//-----------------------------------------------------------------------
// <copyright file="ApplicationDbContext.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using WebAruhaz.Models.InvoiceModels;
    using WebAruhaz.Models.UserModels;
    using WebAruhaz.Models.WarehouseModels;
    using WebAruhaz.Models.WebShopModels;

    /// <summary>
    /// Defines the <see cref="ApplicationDbContext" />
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options<see cref="DbContextOptions{ApplicationDbContext}"/></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the ApplicationUsers
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        /// <summary>
        /// Gets or sets the Currencies
        /// </summary>
        public DbSet<Currency> Currencies { get; set; }

        /// <summary>
        /// Gets or sets the Customers
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the Invoices
        /// </summary>
        public DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// Gets or sets the Taxes
        /// </summary>
        public DbSet<Tax> Taxes { get; set; }

        /// <summary>
        /// Gets or sets the Vendors
        /// </summary>
        public DbSet<Vendor> Vendors { get; set; }

        /// <summary>
        /// Gets or sets the Products
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the CartLines
        /// </summary>
        public DbSet<CartLine> CartLines { get; set; }

        /// <summary>
        /// Gets or sets the Orders
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the OrderDetails
        /// </summary>
        public DbSet<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// Gets or sets the Categories
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the WareHouses
        /// </summary>
        public DbSet<WareHouse> WareHouses { get; set; }

        /// <summary>
        /// Gets or sets the Racks
        /// </summary>
        public DbSet<Rack> Racks { get; set; }
    }
}
