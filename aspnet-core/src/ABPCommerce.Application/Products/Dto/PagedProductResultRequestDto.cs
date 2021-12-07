using Abp.Application.Services.Dto;

namespace ABPCommerce.Products.Dto
{
    public class PagedProductResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
