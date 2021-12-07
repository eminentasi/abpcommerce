using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABPCommerce.Catalog.Product;
using System.Collections.Generic;

namespace ABPCommerce.Products.Dto
{
    [AutoMap(typeof(Product))]
    public class ProductDto: EntityDto
    {
        // Mapped from Product.Price
        public decimal Price { get; set; }
        // Mapped from ProductTranslation.Name
        public string Name { get; set; }

        public List<ProductTranslationDto> Translations { get; set; }
    }
}
