using Abp.AutoMapper;
using ABPCommerce.Catalog.Category;
using ABPCommerce.Categories.Dto;
using AutoMapper;

namespace ABPCommerce.Categories.Mapping
{
    public static class CategoriesDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration, MultiLingualMapContext context)
        {
            configuration.CreateMultiLingualMap<Category, CategoryTranslation, CategoryDto>(context).EntityMap
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
