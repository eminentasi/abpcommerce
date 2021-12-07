using Abp.Application.Services.Dto;

namespace ABPCommerce.Orders.Dto
{
    public class PagedOrderResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
