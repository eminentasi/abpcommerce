using Abp.Domain.Entities;
using System.Collections.Generic;

namespace ABPCommerce.Catalog.Category
{
    public class Category : Entity, IMultiLingualEntity<CategoryTranslation>
    {
        public int DisplayOrder { get; set; }

        public ICollection<CategoryTranslation> Translations { get; set; }
        public ICollection<Product.Product> Products { get; set; }
    }
}
