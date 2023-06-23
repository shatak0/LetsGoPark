using LetsGoPark.WebSite.Models;
using LetsGoPark.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LetsGoPark.WebSite.Pages.Product
{
    public class ReadModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }
        public ProductModel Product;
        public void OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }
    }
}