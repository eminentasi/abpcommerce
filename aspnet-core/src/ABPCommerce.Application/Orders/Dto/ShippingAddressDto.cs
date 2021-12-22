using Abp.Application.Services.Dto;
using ABPCommerce.OrderManagement.Shipping;
using System.ComponentModel.DataAnnotations;

namespace ABPCommerce.Orders.Dto
{
    public class ShippingAddressDto : EntityDto
    {
        [MaxLength(ShippingAddress.NameMaxLength)]
        public string FirstName { get; set; }
        [MaxLength(ShippingAddress.NameMaxLength)]
        public string LastName { get; set; }
        [MaxLength(ShippingAddress.CompanyNameMaxLength)]
        public string CompanyName { get; set; }
        [MaxLength(ShippingAddress.NameMaxLength)]
        public string Country { get; set; }
        [MaxLength(ShippingAddress.NameMaxLength)]
        public string State { get; set; }
        [MaxLength(ShippingAddress.NameMaxLength)]
        public string City { get; set; }
        [MaxLength(ShippingAddress.PostcodeMaxLength)]
        public string Postcode { get; set; }
        [MaxLength(ShippingAddress.AddressMaxLength)]
        public string Address { get; set; }
    }
}
