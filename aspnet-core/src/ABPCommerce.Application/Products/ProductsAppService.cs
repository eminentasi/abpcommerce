using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ABPCommerce.Catalog.Product;
using ABPCommerce.Products.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCommerce.Products
{
    public class ProductsAppService : AsyncCrudAppService<Product, ProductDto, int, PagedProductResultRequestDto>, IProductsAppService
    {
        private readonly IRepository<Product> _repository;

        public ProductsAppService(IRepository<Product> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public override async Task<PagedResultDto<ProductDto>> GetAllAsync(PagedProductResultRequestDto input)
        {
            var query = _repository.GetAllIncluding(p => p.Translations);

            if (!string.IsNullOrEmpty(input.Keyword))
            {
                query = query.Where(p => p.Translations.Any(p => p.Name.Contains(input.Keyword)));
            }

            var products = await query.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            return new PagedResultDto<ProductDto>(await query.CountAsync(), ObjectMapper.Map<List<ProductDto>>(products));
        }

        public override async Task<ProductDto> GetAsync(EntityDto<int> input)
        {
            var product = await _repository.GetAllIncluding(p => p.Translations, p => p.Category).FirstOrDefaultAsync(p => p.Id == input.Id);
            return ObjectMapper.Map<ProductDto>(product);
        }

        public override async Task<ProductDto> UpdateAsync(ProductDto input)
        {
            var product = await _repository.GetAllIncluding(p => p.Translations, p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == input.Id);

            product.Translations.Clear();

            ObjectMapper.Map(input, product);
            await _repository.UpdateAsync(product);
            return ObjectMapper.Map<ProductDto>(product);
        }
    }
}
