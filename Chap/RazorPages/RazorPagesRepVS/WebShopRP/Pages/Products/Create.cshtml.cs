using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShopRP.Services;
using WebShopRP.Models;

namespace WebShopRP.Pages.Products
{
    public class CreateModel : PageModel
    {
        private IProductDataService productDataService;
        [BindProperty]
        public Product Data { get; set; } = new Product();
        public CreateModel(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }
       public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            productDataService.Create(Data);
            return RedirectToPage("All");
        }
    }
}
