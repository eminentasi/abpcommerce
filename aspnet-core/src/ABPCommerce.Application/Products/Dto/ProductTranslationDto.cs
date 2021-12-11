using Abp.AutoMapper;
using ABPCommerce.Catalog.Product;
using System.ComponentModel.DataAnnotations;

namespace ABPCommerce.Products.Dto
{
    [AutoMap(typeof(ProductTranslation))]
    public class ProductTranslationDto
    {
        [MaxLength(ProductTranslation.NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(ProductTranslation.DescriptionMaxLength)]
        public string Description { get; set; }

        public string Language { get; set; }
    }
}
