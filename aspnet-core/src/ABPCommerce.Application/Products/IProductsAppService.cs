using Abp.Application.Services;
using ABPCommerce.Products.Dto;

namespace ABPCommerce.Products
{
    public interface IProductsAppService : IAsyncCrudAppService<ProductDto, int, PagedProductResultRequestDto>
    {

    }
}
