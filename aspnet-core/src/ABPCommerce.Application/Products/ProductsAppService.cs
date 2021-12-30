using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ABPCommerce.Authorization;
using ABPCommerce.Catalog.Product;
using ABPCommerce.Products.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABPCommerce.Products
{
    [AbpAuthorize(PermissionNames.Pages_Products)]
    public class ProductsAppService : AsyncCrudAppService<Product, ProductDto, int, PagedProductResultRequestDto>, IProductsAppService
    {
        public ProductsAppService(IRepository<Product> repository)
            : base(repository)
        {
            
        }

        public override async Task<PagedResultDto<ProductDto>> GetAllAsync(PagedProductResultRequestDto input)
        {
            CheckGetAllPermission();
            var query = Repository.GetAllIncluding(p => p.Translations);

            if (!string.IsNullOrEmpty(input.Keyword))
            {
                query = query.Where(p => p.Translations.Any(p => p.Name.Contains(input.Keyword)));
            }

            var products = await query.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            return new PagedResultDto<ProductDto>(await query.CountAsync(), ObjectMapper.Map<List<ProductDto>>(products));
        }

        public override async Task<ProductDto> GetAsync(EntityDto<int> input)
        {
            CheckGetPermission();
            var product = await Repository.GetAllIncluding(p => p.Translations, p => p.Category).FirstOrDefaultAsync(p => p.Id == input.Id);
            return ObjectMapper.Map<ProductDto>(product);
        }

        public override async Task<ProductDto> UpdateAsync(ProductDto input)
        {
            CheckUpdatePermission();
            var product = await Repository.GetAllIncluding(p => p.Translations, p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == input.Id);

            product.Translations.Clear();

            ObjectMapper.Map(input, product);
            await Repository.UpdateAsync(product);
            return ObjectMapper.Map<ProductDto>(product);
        }
    }
}
