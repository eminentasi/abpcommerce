using Abp.AutoMapper;
using ABPCommerce.Catalog.Category;

namespace ABPCommerce.Categories.Dto
{
    [AutoMap(typeof(CategoryTranslation))]
    public class CategoryTranslationDto
    {
        public string Name { get; set; }

        public string Language { get; set; }
    }
}
