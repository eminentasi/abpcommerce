using Abp.AutoMapper;
using ABPCommerce.Catalog.Product;

namespace ABPCommerce.Products.Dto
{
    [AutoMap(typeof(ProductTranslation))]
    public class ProductTranslationDto
    {
        public string Name { get; set; }

        public string Language { get; set; }
    }
}
