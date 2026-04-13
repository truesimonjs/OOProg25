using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShopRP.Models;
using WebShopRP.Services;

namespace WebShopRP.Pages.Products
{
    public class AllModel : PageModel
    {
        public IProductDataService productDataService;

        public AllModel(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }

        public List<Product> Data { get; private set; }


        public void OnGet()
        {
            Data = productDataService.GetAll();
        }
    }
}
