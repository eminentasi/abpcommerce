using Abp.Domain.Entities;

namespace ABPCommerce.Catalog.Product
{
    public class ProductTranslation : Entity, IEntityTranslation<Product>
    {
        public string Name { get; set; }

        public Product Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
