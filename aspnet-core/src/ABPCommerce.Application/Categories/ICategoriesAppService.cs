using Abp.Application.Services;
using ABPCommerce.Categories.Dto;

namespace ABPCommerce.Categories
{
    public interface ICategoriesAppService : IAsyncCrudAppService<CategoryDto, int, PagedCategoryResultRequestDto>
    {

    }
}
