using WebShopRP.Models;

namespace WebShopRP.Services
{
    public interface IProductDataService
    {
        List<Product> GetAll();
        int Create(Product product);
    }
   
}
