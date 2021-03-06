using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ABPCommerce.Catalog.Product
{
    public class ProductTranslation : Entity, IEntityTranslation<Product>
    {
        public const int NameMaxLength = 400;
        public const int DescriptionMaxLength = 1024;

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public Product Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
