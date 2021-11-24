﻿using Abp.Application.Services;
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
    public class ProductsAppService : ApplicationService, IProductsAppService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductsAppService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ListResultDto<ProductListDto>> GetProducts()
        {
            var products = await _productRepository.GetAllIncluding(p => p.Translations).ToListAsync();
            return new ListResultDto<ProductListDto>(ObjectMapper.Map<List<ProductListDto>>(products));
        }
        public async Task<ProductDto> GetProduct(int id)
        {
            var product = await _productRepository.GetAllIncluding(p => p.Translations)
                .FirstOrDefaultAsync(p => p.Id == id);

            return ObjectMapper.Map<ProductDto>(product);
        }

        public async Task CreateProduct(ProductDto input)
        {
            var product = ObjectMapper.Map<Product>(input);
            await _productRepository.InsertAsync(product);
        }

        public async Task UpdateProduct(ProductDto input)
        {
            var product = await _productRepository.GetAllIncluding(p => p.Translations)
                .FirstOrDefaultAsync(p => p.Id == input.Id);

            product.Translations.Clear();

            ObjectMapper.Map(input, product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}