using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABPCommerce.Catalog.Category;
using System.Collections.Generic;

namespace ABPCommerce.Categories.Dto
{
    [AutoMap(typeof(Category))]
    public class CategoryDto: EntityDto
    {
        // Mapped from Category.Price
        public decimal Price { get; set; }
        // Mapped from CategoryTranslation.Name
        public string Name { get; set; }

        public List<CategoryTranslationDto> Translations { get; set; }
    }
}
