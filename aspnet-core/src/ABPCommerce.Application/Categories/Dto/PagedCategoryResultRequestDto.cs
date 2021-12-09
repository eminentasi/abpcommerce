using Abp.Application.Services.Dto;

namespace ABPCommerce.Categories.Dto
{
    public class PagedCategoryResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
