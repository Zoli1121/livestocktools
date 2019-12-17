//-----------------------------------------------------------------------
// <copyright file="ProductAdminController.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Controllers.AdminControllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using WebAruhaz.Models.UserModels;
    using WebAruhaz.Models.WarehouseModels;
    using WebAruhaz.Models.WebShopModels;
    using WebAruhaz.Services.WarehouseServices.Interfaces;
    using WebAruhaz.Services.WebShopServices.Interfaces;

    /// <summary>
    /// Defines the <see cref="ProductAdminController" />
    /// </summary>
    public class ProductAdminController : Controller
    {
        /// <summary>
        /// Defines the _hostingEnvironment
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;

        /// <summary>
        /// Defines the _userManager
        /// </summary>
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// Defines the _productService
        /// </summary>
        private readonly IProductService productService;

        /// <summary>
        /// Defines the _categoryService
        /// </summary>
        private readonly ICategoryService categoryService;

        /// <summary>
        /// Defines the _wareHouseService
        /// </summary>
        private readonly IWareHouseService wareHouseService;

        /// <summary>
        /// Defines the _rackService
        /// </summary>
        private readonly IRackService rackService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAdminController"/> class.
        /// </summary>
        /// <param name="hostingEnvironment">The hostingEnvironment<see cref="IHostingEnvironment"/></param>
        /// <param name="userManager">The userManager<see cref="UserManager{ApplicationUser}"/></param>
        /// <param name="productService">The productService<see cref="IProductService"/></param>
        /// <param name="categoryService">The categoryService<see cref="ICategoryService"/></param>
        /// <param name="wareHouseService">The wareHouseService<see cref="IWareHouseService"/></param>
        /// <param name="rackService">The rackService<see cref="IRackService"/></param>
        public ProductAdminController(IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager, IProductService productService, ICategoryService categoryService, IWareHouseService wareHouseService, IRackService rackService)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
            this.categoryService = categoryService;
            this.productService = productService;
            this.rackService = rackService;
            this.wareHouseService = wareHouseService;
        }

        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ViewResult"/></returns>
        public ViewResult Index() => View(productService.Products);

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="productID">The productID<see cref="int"/></param>
        /// <returns>The <see cref="ViewResult"/></returns>
        [HttpGet]
        public ViewResult Edit(int productID)
        {
            Product product = productService.Products.FirstOrDefault(p => p.ProductId == productID);

            List<Category> categories = categoryService.Categories.Where(v => v.Childs == null && v.Parent != null).ToList();
            List<Rack> racks = rackService.Racks.ToList();
            List<WareHouse> wareHouses = wareHouseService.WareHouses.ToList();
            ViewData["CategoryRefId"] = new SelectList(categories, "CategoryId", "CategoryName");
            ViewData["RackRefId"] = new SelectList(racks, "RackCode", "RackNumber");
            ViewData["WareHouseRefId"] = new SelectList(wareHouses, "WareHouseId", "WareHouseName");
            return View(product);
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="product">The product<see cref="Product"/></param>
        /// <param name="photo">The photo<see cref="IFormFile"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpPost]
        public IActionResult Edit(Product product, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                product.SmallImage = photo.FileName;
                productService.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <returns>The <see cref="ViewResult"/></returns>
        [HttpGet]
        public ViewResult Create()
        {
            Product product = new Product();
            List<Category> categories = categoryService.Categories.Where(v => v.Parent == null).ToList();
            List<Rack> racks = rackService.Racks.ToList();
            List<WareHouse> wareHouses = wareHouseService.WareHouses.ToList();
            ViewData["CategoryRefId"] = new SelectList(categories, "CategoryId", "CategoryName");
            ViewData["RackRefId"] = new SelectList(racks, "RackCode", "RackNumber");
            ViewData["WareHouseRefId"] = new SelectList(wareHouses, "WareHouseId", "WareHouseName");
            return View(product);
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="product">The product<see cref="Product"/></param>
        /// <param name="photo">The photo<see cref="IFormFile"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                product.SmallImage = photo.FileName;
                productService.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                productService.Update(product);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="productId">The productId<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = productService.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// The GetSubCategory
        /// </summary>
        /// <param name="categoryRefId">The CategoryRefId<see cref="int"/></param>
        /// <returns>The <see cref="JsonResult"/></returns>
        public JsonResult GetSubCategory(int categoryRefId)
        {
            List<Category> subCategorylist = categoryService.Categories.Where(x => x.ParentId == categoryRefId).ToList();
            return Json(new SelectList(subCategorylist, "CategoryId", "CategoryName"));
        }

        /// <summary>
        /// The GetSubSubCategory
        /// </summary>
        /// <param name="subCatId">The subCatId<see cref="int"/></param>
        /// <returns>The <see cref="JsonResult"/></returns>
        public JsonResult GetSubSubCategory(int subCatId)
        {
            List<Category> subCategorylist = categoryService.Categories.Where(x => x.ParentId == subCatId).ToList();
            return Json(new SelectList(subCategorylist, "CategoryId", "CategoryName"));
        }
    }
}
