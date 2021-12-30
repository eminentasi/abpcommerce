using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ABPCommerce.Authorization;
using ABPCommerce.Catalog.Category;
using ABPCommerce.Categories.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABPCommerce.Categories
{
    [AbpAuthorize(PermissionNames.Pages_Categories)]
    public class CategoriesAppService : AsyncCrudAppService<Category, CategoryDto, int, PagedCategoryResultRequestDto>, ICategoriesAppService
    {
        public CategoriesAppService(IRepository<Category> repository)
            : base(repository)
        {
            
        }

        public override async Task<PagedResultDto<CategoryDto>> GetAllAsync(PagedCategoryResultRequestDto input)
        {
            CheckGetAllPermission();
            var query = Repository.GetAllIncluding(p => p.Translations);

            if (!string.IsNullOrEmpty(input.Keyword))
            {
                query = query.Where(p => p.Translations.Any(p => p.Name.Contains(input.Keyword)));
            }

            var products = await query.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            return new PagedResultDto<CategoryDto>(await query.CountAsync(), ObjectMapper.Map<List<CategoryDto>>(products));
        }

        public override async Task<CategoryDto> GetAsync(EntityDto<int> input)
        {
            CheckGetPermission();
            var product = await Repository.GetAllIncluding(p => p.Translations).FirstOrDefaultAsync(p => p.Id == input.Id);
            return ObjectMapper.Map<CategoryDto>(product);
        }

        public override async Task<CategoryDto> UpdateAsync(CategoryDto input)
        {
            CheckUpdatePermission();
            var product = await Repository.GetAllIncluding(p => p.Translations)
                .FirstOrDefaultAsync(p => p.Id == input.Id);

            product.Translations.Clear();

            ObjectMapper.Map(input, product);
            await Repository.UpdateAsync(product);
            return ObjectMapper.Map<CategoryDto>(product);
        }
    }
}
