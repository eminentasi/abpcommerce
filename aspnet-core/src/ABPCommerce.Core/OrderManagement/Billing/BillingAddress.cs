using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ABPCommerce.OrderManagement.Billing
{
    public class BillingAddress : Entity
    {
        public const int NameMaxLength = 255;
        public const int AddressMaxLength = 500;
        public const int PostcodeMaxLength = 10;
        public const int TaxIdMaxLength = 32;

        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }
        [MaxLength(500)]
        public string CompanyName { get; set; }
        [MaxLength(NameMaxLength)]
        public string Country { get; set; }
        [MaxLength(NameMaxLength)]
        public string State { get; set; }
        [MaxLength(NameMaxLength)]
        public string City { get; set; }
        [MaxLength(PostcodeMaxLength)]
        public string Postcode { get; set; }
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }
        [MaxLength(TaxIdMaxLength)]
        public string TaxId { get; set; }
    }
}
