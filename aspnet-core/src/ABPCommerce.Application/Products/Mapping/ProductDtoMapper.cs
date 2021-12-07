using Abp.AutoMapper;
using ABPCommerce.Catalog.Product;
using ABPCommerce.Products.Dto;
using AutoMapper;

namespace ABPCommerce.Products.Mapping
{
    public static class ProductDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration, MultiLingualMapContext context)
        {
            configuration.CreateMultiLingualMap<Product, ProductTranslation, ProductDto>(context).EntityMap
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
