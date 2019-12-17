//-----------------------------------------------------------------------
// <copyright file="Startup.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz
{
    using System;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
  
    using WebAruhaz.AccessManagement;
    using WebAruhaz.Data;
    using WebAruhaz.Models.UserModels;
    using WebAruhaz.Services.WarehouseServices;
    using WebAruhaz.Services.WarehouseServices.Interfaces;
    using WebAruhaz.Services.WebShopServices;
    using WebAruhaz.Services.WebShopServices.Interfaces;

    /// <summary>
    /// Defines the <see cref="Startup" />
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/></param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// The ConfigureServices
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/></param>
        public void ConfigureServices(IServiceCollection services)
        {
            ////Registers the given context as a service in the Microsoft.Extensions.DependencyInjection.IServiceCollection.
            ////You use this method when using dependency injection in your application :
            services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            IConfigurationSection configSection = Configuration.GetSection("DefaultIdentityOptions");
            services.Configure<IdentitySettings>(configSection);
            IdentitySettings identitySettings = configSection.Get<IdentitySettings>();
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = identitySettings.PasswordDigit;
                options.Password.RequiredLength = identitySettings.PasswordLength;
                options.Password.RequireNonAlphanumeric = identitySettings.PasswordNonAlphanumeric;
                options.Password.RequireUppercase = identitySettings.PasswordUppercase;
                options.Password.RequireLowercase = identitySettings.PasswordLowercase;
                options.Password.RequiredUniqueChars = identitySettings.PasswordChars;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(identitySettings.LockoutTimeSpanInMinutes);
                options.Lockout.MaxFailedAccessAttempts = identitySettings.MaxFailedAccessAttempts;
                options.Lockout.AllowedForNewUsers = identitySettings.AllowedForNewUsers;

                options.User.RequireUniqueEmail = identitySettings.UserUniqueEmail;

                options.SignIn.RequireConfirmedEmail = identitySettings.SignInConfirmedEmail;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");
            services.Configure<SMTP>(Configuration.GetSection("SmtpOptions"));
            services.AddScoped(c => CartService.GetCart(c));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IRackService, RackService>();
            services.AddTransient<IWareHouseService, WareHouseService>();
            services.AddSession();
            services.AddMvc();
            services.AddMemoryCache();
        }

        /// <summary>
        /// The Configure
        /// </summary>
        /// <param name="app">The app<see cref="IApplicationBuilder"/></param>
        /// <param name="env">The env<see cref="IHostingEnvironment"/></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "productdetails",
                    template: "Product/Details/{productId?}",
                    defaults: new { Controller = "Product", action = "Details" });

                routes.MapRoute(
                    name: "categoryfilter",
                    template: "Product/{action}/{category?}",
                    defaults: new { Controller = "Product", action = "List" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{Id?}");
            });
            DatabaseInitializer.CreateDatabase(app);
        }
    }
}
