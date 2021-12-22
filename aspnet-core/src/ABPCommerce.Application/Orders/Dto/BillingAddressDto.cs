using Abp.Application.Services.Dto;
using ABPCommerce.OrderManagement.Billing;
using System.ComponentModel.DataAnnotations;

namespace ABPCommerce.Orders.Dto
{
    public class BillingAddressDto : EntityDto
    {
        [MaxLength(BillingAddress.NameMaxLength)]
        public string FirstName { get; set; }
        [MaxLength(BillingAddress.NameMaxLength)]
        public string LastName { get; set; }
        [MaxLength(500)]
        public string CompanyName { get; set; }
        [MaxLength(BillingAddress.NameMaxLength)]
        public string Country { get; set; }
        [MaxLength(BillingAddress.NameMaxLength)]
        public string State { get; set; }
        [MaxLength(BillingAddress.NameMaxLength)]
        public string City { get; set; }
        [MaxLength(BillingAddress.PostcodeMaxLength)]
        public string Postcode { get; set; }
        [MaxLength(BillingAddress.AddressMaxLength)]
        public string Address { get; set; }
        [MaxLength(BillingAddress.TaxIdMaxLength)]
        public string TaxId { get; set; }
    }
}
