using Abp.Domain.Entities;
using System.Collections.Generic;

namespace ABPCommerce.Catalog.Product
{
    public class Product : Entity, IMultiLingualEntity<ProductTranslation>
    {
        public decimal Price { get; set; }
        public decimal? SalesPrice { get; set; }
        public int? CategoryId { get; set; }

        public ICollection<ProductTranslation> Translations { get; set; }
        public Category.Category Category { get; set; }
    }
}
