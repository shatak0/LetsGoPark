using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using LetsGoPark.WebSite.Models;
using LetsGoPark.WebSite.Services;


/// CreateModel page injects a JsonFileProductService dependency and handles GET requests by creating or retrieving a Product object.
/// Redirecting to the Update page.

namespace LetsGoPark.WebSite.Pages.Product
{
    public class CreateModel : PageModel
    {
        // Data middle tier
        public JsonFileProductService ProductService { get; }

        
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show
        public ProductModel Product;

        
        /// REST Get request
        
        /// <param name="id"></param>
        public IActionResult OnGet()
        {
            Product = ProductService.CreateData();

            return RedirectToPage("./Update", new { Id = Product.Id });
        }
    }
}