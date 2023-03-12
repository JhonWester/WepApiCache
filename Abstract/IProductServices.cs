using ApiCaching.Models;

namespace ApiCaching.Abstract
{
    public interface IProductServices
    {
        Task<IList<Product>> GetProducts();
    }
}
