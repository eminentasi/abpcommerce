using Abp.AutoMapper;
using ABPCommerce.Catalog.Category;
using System.ComponentModel.DataAnnotations;

namespace ABPCommerce.Categories.Dto
{
    [AutoMap(typeof(CategoryTranslation))]
    public class CategoryTranslationDto
    {
        [MaxLength(CategoryTranslation.NameMaxLength)]
        public string Name { get; set; }
        [MaxLength(CategoryTranslation.DescriptionMaxLength)]
        public string Description { get; set; }

        public string Language { get; set; }
    }
}
