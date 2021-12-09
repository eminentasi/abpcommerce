using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ABPCommerce.Catalog.Category
{
    public class CategoryTranslation : Entity, IEntityTranslation<Category>
    {
        public const int NameMaxLength = 255;
        public const int DescriptionMaxLength = 1024;

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public Category Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
