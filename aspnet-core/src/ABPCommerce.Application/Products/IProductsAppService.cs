using Abp.Application.Services.Dto;
using ABPCommerce.Products.Dto;
using System.Threading.Tasks;

namespace ABPCommerce.Products
{
    interface IProductsAppService
    {
        Task<ListResultDto<ProductListDto>> GetProducts();
        Task<ProductDto> GetProduct(int id);
        Task CreateProduct(ProductDto input);
        Task UpdateProduct(ProductDto input);
        Task DeleteAsync(int id);
    }
}
