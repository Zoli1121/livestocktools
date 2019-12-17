//-----------------------------------------------------------------------
// <copyright file="DatabaseInitializer.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using WebAruhaz.Models.UserModels;
    using WebAruhaz.Models.WarehouseModels;
    using WebAruhaz.Models.WebShopModels;

    /// <summary>
    /// Defines the <see cref="DatabaseInitializer" />
    /// </summary>
    public class DatabaseInitializer
    {
        /// <summary>
        /// Defines the products
        /// </summary>
        private static Dictionary<string, Product> products;

        /// <summary>
        /// Defines the wareHouses
        /// </summary>
        private static Dictionary<string, WareHouse> wareHouses;

        /// <summary>
        /// Defines the categories
        /// </summary>
        private static Dictionary<string, Category> categories;

        /// <summary>
        /// Defines the racks
        /// </summary>
        private static Dictionary<string, Rack> racks;

        /// <summary>
        /// Gets the Products
        /// </summary>
        public static Dictionary<string, Product> Products
        {
            get
            {
                List<Product> productsList = new List<Product>();
                if (products == null)
                {
                    Product p1 = new Product();
                    p1.Name = "termek1";
                    p1.PartNumber = "kr1023";
                    p1.Price = 2000;
                    p1.Description = "blablba";
                    p1.SmallImage = "KR144.jpg";
                    p1.CategoryRefId = GetSubSubCategoryId("Állattenyésztés", null, null);
                    p1.SubCategoryRefId = GetSubSubCategoryId("Állattenyésztés", "Állatápolás", null);
                    p1.SubSubCategoryRefId = GetSubSubCategoryId("Állattenyésztés", "Állatápolás", "Nyírógépek");
                    p1.Rack = Racks["A00E02"];
                    p1.Weight = 10;
                    productsList.Add(p1);
                }

                products = new Dictionary<string, Product>();
                foreach (Product product in productsList)
                {
                    products.Add(product.Name, product);
                }

                return products;
            }
        }

        /// <summary>
        /// Gets the WareHouses
        /// </summary>
        public static Dictionary<string, WareHouse> WareHouses
        {
            get
            {
                if (wareHouses == null)
                {
                    WareHouse[] wareHousesList = new WareHouse[]
                    {
            new WareHouse
            {
              WareHouseName = "R0146"
            },
            new WareHouse
            {
              WareHouseName = "R0147"
            },
            new WareHouse
            {
              WareHouseName = "R0148"
            },
            new WareHouse
            {
              WareHouseName = "R0149"
            }
                    };
                    wareHouses = new Dictionary<string, WareHouse>();
                    foreach (WareHouse wareHouse in wareHousesList)
                    {
                        wareHouses.Add(wareHouse.WareHouseName, wareHouse);
                    }
                }

                return wareHouses;
            }
        }

        /// <summary>
        /// Gets the Categories
        /// </summary>
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    Category[] categoryList = new Category[]
                    {
            new Category
            {
              CategoryName = "Állattenyésztés",

              Childs = new List<Category>
              {
                new Category
                  {
                    CategoryName = "Állatápolás",
                    Childs = new List<Category>
                    {
                      new Category
                      {
                        CategoryName = "Nyírógépek"
                      },
                      new Category
                      {
                        CategoryName = "Kefék,vakaródzók"
                      },
                      new Category
                      {
                        CategoryName = "Csülökápolás"
                      },
                      new Category
                      {
                        CategoryName = "Fürösztés, fertőtlenítés"
                      }
                    }
                  },
                new Category
                  {
                    CategoryName = "Tej minőségvizsgálat",
                    Childs = new List<Category>
                    {
                      new Category
                      {
                        CategoryName = "Gátlóanyag-vizsgálat tejben"
                      },
                      new Category
                      {
                        CategoryName = "Beltartalom-vizsgálat"
                      },
                      new Category
                      {
                        CategoryName = "Szomatikus sejtszámmérés"
                      },
                      new Category
                      {
                        CategoryName = "Funke-Gerber termékek"
                      }
                    }
                  },
                new Category
                {
                  CategoryName = "Etetéstechnológia"
                },
                new Category
                {
                  CategoryName = "Állatjelölés, állatazonosítás",
                  Childs = new List<Category>
                  {
                    new Category
                    {
                      CategoryName = "Állatjelölő spray-k"
                    },
                    new Category
                    {
                      CategoryName = "Állatjelölő kréták"
                    },
                    new Category
                    {
                      CategoryName = "Tetoválás eszközei"
                    },
                    new Category
                    {
                      CategoryName = "Jelölő kötelek, egyéb állatjelölés"
                    },
                    new Category
                    {
                      CategoryName = "Vizuális füljelzők"
                    },
                    new Category
                    {
                      CategoryName = "Elektromos állatazonosítás"
                    }
                  }
                },
                new Category
                {
                  CategoryName = "Fejés-, és hűtéstechnológia",
                  Childs = new List<Category>
                  {
                    new Category
                    {
                      CategoryName = "Tejhűtők"
                    },
                    new Category
                    {
                      CategoryName = "Telepített fejőberendezések"
                    },
                    new Category
                    {
                      CategoryName = "Mobil fejőgépek"
                    },
                    new Category
                    {
                      CategoryName = "Tőgykenőcsök, egyéb tőgyápolás"
                    },
                    new Category
                    {
                      CategoryName = "Fejéstechnikai részegységek"
                    },
                  }
                },
                new Category
                {
                  CategoryName = "Itatástechnológia"
                },
                new Category
                {
                  CategoryName = "Kártevőmentesítés",
                  Childs = new List<Category>
                  {
                    new Category
                    {
                      CategoryName = "Rágcsálóírtás"
                    },
                    new Category
                    {
                      CategoryName = "Rovarirtás"
                    },
                    new Category
                    {
                      CategoryName = "Egyéb riasztók"
                    },
                    new Category
                    {
                      CategoryName = "Élvefogó csapdák"
                    },
                  }
                },
                new Category
                {
                  CategoryName = "Mesterséges termékenyítés", Childs = new List<Category>
                  {
                    new Category
                    {
                      CategoryName = "Katéterek"
                    },
                    new Category
                    {
                      CategoryName = "Spermaflakonok"
                    },
                    new Category
                    {
                      CategoryName = "Spermahígítók"
                    },
                    new Category
                    {
                      CategoryName = "Kesztyűk"
                    },
                    new Category
                    {
                      CategoryName = "Inszemináló pisztolyok"
                    },
                    new Category
                    {
                      CategoryName = "Poharak, termoszok, konténerek"
                    },
                  }
                },
                new Category
                {
                  CategoryName = "Tartástechnológia",
                  Childs = new List<Category>
                  {
                    new Category
                    {
                      CategoryName = "Karámrendszerek"
                    },
                    new Category
                    {
                      CategoryName = "Állatmérlegelés"
                    },
                    new Category
                    {
                      CategoryName = "Elletés eszközei"
                    },
                    new Category
                    {
                      CategoryName = "Kalodák"
                    },
                    new Category
                    {
                      CategoryName = "Állatrögzítés, fékezés"
                    },
                    new Category
                    {
                      CategoryName = "Borjú nevelés"
                    },
                    new Category
                    {
                      CategoryName = "Munkaruházat, védőfelszerelések"
                    },
                    new Category
                    {
                      CategoryName = "Bárány, gida nevelés"
                    },
                    new Category
                    {
                      CategoryName = "Szellőzés, klímatechnológia"
                    },
                    new Category
                    {
                      CategoryName = "Sertés technológia"
                    },
                    new Category
                    {
                      CategoryName = "Baromfi technológia"
                    },
                  }
                },
                new Category
                {
                  CategoryName = "Tejkezelés",
                  Childs = new List<Category>
                  {
                    new Category
                    {
                      CategoryName = "Sajtkádak pasztőrkádak"
                    },
                    new Category
                    {
                      CategoryName = "Sajtkészítés egyéb berendezései"
                    },
                  }
                },
                new Category
                {
                  CategoryName = "Villanypásztor",
                  Childs = new List<Category>
                  {
                    new Category
                    {
                      CategoryName = "Trafók"
                    },
                    new Category
                    {
                      CategoryName = "Szigetelők"
                    },
                    new Category
                    {
                      CategoryName = "Vezetékek"
                    },
                    new Category
                    {
                      CategoryName = "Szalagok"
                    },
                    new Category
                    {
                      CategoryName = "Kapuk"
                    },
                    new Category
                    {
                      CategoryName = "Oszlopok"
                    },
                    new Category
                    {
                      CategoryName = "Napelemek"
                    },
                    new Category
                    {
                      CategoryName = "Egyéb tartozékok, kiegészítők"
                    },
                  }
                },
                new Category
                {
                  CategoryName = "Tisztító és fertőtlenítő gépek"
                }
              }
            },
            new Category
            {
              CategoryName = "Higiénia",

              Childs = new List<Category>
              {
                new Category
                {
                  CategoryName = "Istálló higiénia",
                  Childs = new List<Category>
                  {
                    new Category
                    {
                      CategoryName = "Lúgos tistítószerek"
                    },
                    new Category
                    {
                      CategoryName = "Savas tisztítószerek"
                    },
                    new Category
                    {
                      CategoryName = "Semleges tisztítószerek"
                    },
                    new Category
                    {
                      CategoryName = "Habosítható fertőtlenítők"
                    },
                    new Category
                    {
                      CategoryName = "Ködösíthető fertőtlenítők"
                    },
                    new Category
                    {
                      CategoryName = "Egyéb fertőtlenítők"
                    },
                  }
                },
                new Category
                {
                  CategoryName = "Ivóvíz Higiénia",
                },
                new Category
                {
                  CategoryName = "TőgyHigiénia",
                },
                new Category
                {
                  CategoryName = "CSülök és pataápolók"
                },
                new Category
                {
                  CategoryName = "Alomhigiénia",
                },
                new Category
                {
                  CategoryName = "Személyi higiénia",
                },
                new Category
                {
                  CategoryName = "Tisztító gépek",
                }
              }
            },
            new Category
            {
              CategoryName = "Lovas ágazat",

              Childs = new List<Category>
              {
                new Category
                {
                  CategoryName = "Mustad patkolási termékek",
                  Childs = new List<Category>
                  {
                    new Category
                    {
                      CategoryName = "MUSTAD patkó szegek"
                    },
                    new Category
                    {
                      CategoryName = "MUSTAD patkók"
                    },
                    new Category
                    {
                      CategoryName = "MUSTAD szerszámok, egyéb felszerelések"
                    },
                    new Category
                    {
                      CategoryName = "Egyéb szerzámok, kiegészítők"
                    },
                  }
                },
                new Category
                {
                  CategoryName = "Ariat",
                },
                new Category
                {
                  CategoryName = "USG",
                },
                new Category
                {
                  CategoryName = "Equistro",
                },
                new Category
                {
                  CategoryName = "OK plast",
                  Childs = new List<Category>
                  {
                    new Category
                    {
                      CategoryName = "OK plast termékek"
                    },
                    new Category
                    {
                      CategoryName = "Melléklet"
                    }
                  }
                },
              }
            },
            new Category
            {
              CategoryName = "Takarmánykiegészítő",

              Childs = new List<Category>
              {
                new Category
                {
                  CategoryName = "Vitapol Suspensio, pulvis"
                },
                new Category
                {
                  CategoryName = "Equistro kiegészítők",
                  Childs = new List<Category>
                  {
                    new Category
                    {
                      CategoryName = "Általános vitaminellátás"
                    },
                    new Category
                    {
                      CategoryName = "Idegrendszer"
                    },
                    new Category
                    {
                      CategoryName = "Légzőszervek"
                    },
                    new Category
                    {
                      CategoryName = "Elektrolit utánpótlás"
                    },
                    new Category
                    {
                      CategoryName = "Teljesítmény"
                    },
                    new Category
                    {
                      CategoryName = "Izomzat"
                    },
                    new Category
                    {
                      CategoryName = "Pata, szőr és bőrvédelem"
                    },
                    new Category
                    {
                      CategoryName = "Emésztés és májvédelem"
                    },
                    new Category
                    {
                      CategoryName = "Izületvédelem"
                    },
                    new Category
                    {
                      CategoryName = "Szaporodás és termékenység fokozás"
                    },
                  }
                },
                new Category
                {
                  CategoryName = "Pegus zsákos lótápok"
                },
                new Category
                {
                  CategoryName = "Nyalósó",
                  Childs = new List<Category>
                  {
                    new Category
                    {
                      CategoryName = "Biosaxon nyalósók"
                    },
                    new Category
                    {
                      CategoryName = "Magyar gyártású takarmánysók"
                    }
                  }
                },
              }
            },
            new Category
            {
              CategoryName = "Vízvizsgálat",

              Childs = new List<Category>
              {
                new Category
                {
                  CategoryName = "IDEXX víz mikrobiológiai termékek"
                }
              }
            }
                    };
                    categories = new Dictionary<string, Category>();
                    foreach (Category mainCategory in categoryList)
                    {
                        categories.Add(mainCategory.CategoryName, mainCategory);
                    }
                }

                return categories;
            }
        }

        /// <summary>
        /// Gets the Racks
        /// </summary>
        public static Dictionary<string, Rack> Racks
        {
            get
            {
                if (racks == null)
                {
                    Rack[] racksList = new Rack[]
                    {
            new Rack
            {
              RackNumber = "A00E02",
              WareHouse = WareHouses["R0149"]
            },
            new Rack
            {
              RackNumber = "A00E03",
              WareHouse = WareHouses["R0149"]
            },
            new Rack
            {
              RackNumber = "A00E04",
              WareHouse = WareHouses["R0149"]
            },
            new Rack
            {
              RackNumber = "A00E05",
              WareHouse = WareHouses["R0149"]
            },
                    };
                    racks = new Dictionary<string, Rack>();
                    foreach (Rack rack in racksList)
                    {
                        racks.Add(rack.RackNumber, rack);
                    }
                }

                return racks;
            }
        }

        /// <summary>
        /// The CreateDatabase
        /// </summary>
        /// <param name="applicationBuilder">The applicationBuilder<see cref="IApplicationBuilder"/></param>
        public static void CreateDatabase(IApplicationBuilder applicationBuilder)
        {
            IServiceScope serviceScope = Program.Host.Services.CreateScope();
            IServiceProvider services = serviceScope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var authService = services.GetRequiredService<IAuthenticationService>();
                Initialize(context, userManager, roleManager, authService, applicationBuilder).Wait();
            }
            catch (Exception ex)
            {
                var message = ex;
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }

            SeedData(applicationBuilder);
        }

        /// <summary>
        /// The Initialize
        /// </summary>
        /// <param name="context">The context<see cref="ApplicationDbContext"/></param>
        /// <param name="userManager">The userManager<see cref="UserManager{ApplicationUser}"/></param>
        /// <param name="roleManager">The roleManager<see cref="RoleManager{IdentityRole}"/></param>
        /// <param name="authService">The authService<see cref="IAuthenticationService"/></param>
        /// <param name="applicationBuilder">The applicationBuilder<see cref="IApplicationBuilder"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IAuthenticationService authService, IApplicationBuilder applicationBuilder)
        {
            context.Database.EnsureCreated();
            if (context.ApplicationUsers.Any())
            {
                return;
            }

            await CreateMainAdmin(userManager, roleManager);
        }

        /// <summary>
        /// The CreateMainAdmin
        /// </summary>
        /// <param name="userManager">The userManager<see cref="UserManager{ApplicationUser}"/></param>
        /// <param name="roleManager">The roleManager<see cref="RoleManager{IdentityRole}"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public static async Task CreateMainAdmin(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                ApplicationUser admin = new ApplicationUser();
                admin.Email = "admin@admin99.com";
                admin.UserName = admin.Email;
                admin.EmailConfirmed = true;
                admin.MainAdmin = true;
                Type adminType = admin.GetType();
                foreach (PropertyInfo item in adminType.GetProperties())
                {
                    if (item.Name.Contains("Role"))
                    {
                        item.SetValue(admin, true);
                    }
                }

                await userManager.CreateAsync(admin, "Admin1234;");
            }
            catch (Exception e)
            {
                var message = e.ToString();
            }
        }

        /// <summary>
        /// The SeedData
        /// </summary>
        /// <param name="applicationBuilder">The applicationBuilder<see cref="IApplicationBuilder"/></param>
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            ApplicationDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    if (!context.Categories.Any())
                    {
                        context.Categories.AddRange(Categories.Select(c => c.Value));
                    }

                    context.SaveChanges();
                    if (!context.WareHouses.Any())
                    {
                        context.WareHouses.AddRange(WareHouses.Select(c => c.Value));
                    }

                    context.SaveChanges();
                    if (!context.Racks.Any())
                    {
                        context.Racks.AddRange(Racks.Select(c => c.Value));
                    }

                    context.SaveChanges();
                    if (!context.Products.Any())
                    {
                        context.Products.AddRange(Products.Select(c => c.Value));
                    }

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    var message = e.ToString();
                    applicationBuilder.Run(async (httpcontext) =>
                    {
                        httpcontext.Response.ContentType = "text/plain; charset = utf-8";
                        await httpcontext.Response.WriteAsync("Hiba történt : \n" + message);
                    });
                    transaction.Rollback();
                }
            }
        }

        /// <summary>
        /// The GetSubCategory
        /// </summary>
        /// <param name="categoryName">The categoryName<see cref="string"/></param>
        /// <param name="subCategoryName">The subCategoryName<see cref="string"/></param>
        /// <returns>The <see cref="Category"/></returns>
        public static Category GetSubCategory(string categoryName, string subCategoryName)
        {
            Category category = Categories[categoryName];
            IEnumerable<Category> childs = category.Childs;
            return childs.Single(x => x.CategoryName == subCategoryName);
        }

        /// <summary>
        /// The GetSubSubCategoryId
        /// </summary>
        /// <param name="categoryName">The categoryName<see cref="string"/></param>
        /// <param name="subCategoryName">The subCategoryName<see cref="string"/></param>
        /// <param name="subSubCategoryName">The subSubCategoryName<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int GetSubSubCategoryId(string categoryName, string subCategoryName, string subSubCategoryName)
        {
            Category parentcategory = Categories[categoryName];
            Category category;
            IEnumerable<Category> childs = parentcategory.Childs;
            IEnumerable<Category> grandChilds;

            if (subCategoryName == null && subSubCategoryName == null)
            {
                return parentcategory.CategoryId;
            }

            if (subSubCategoryName == null)
            {
                category = childs.Single(x => x.CategoryName == subCategoryName);
                return category.CategoryId;
            }

            grandChilds = childs.Single(x => x.CategoryName == subCategoryName).Childs;
            return grandChilds.Single(x => x.CategoryName == subSubCategoryName).CategoryId;
        }
    }
}
