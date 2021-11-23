using ABPCommerce.Products.Dto;
using System.Threading.Tasks;

namespace ABPCommerce.Products
{
    interface IProductsAppService
    {
        Task CreateProduct(ProductDto input);
        Task UpdateProduct(ProductDto input);
        Task DeleteAsync(int id);
    }
}
