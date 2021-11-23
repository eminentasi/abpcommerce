using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCommerce.Products.Dto
{
    public class ProductListDto
    {
        // Mapped from Product.Price
        public decimal Price { get; set; }

        // Mapped from ProductTranslation.Name
        public string Name { get; set; }
    }
}
