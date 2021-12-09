using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCommerce.OrderManagement.Billing
{
    public class BillingAddress : Entity
    {
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }
        [MaxLength(500)]
        public string CompanyName { get; set; }
        [MaxLength(255)]
        public string Country { get; set; }
        [MaxLength(255)]
        public string State { get; set; }
        [MaxLength(255)]
        public string City { get; set; }
        [MaxLength(10)]
        public string Postcode { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(32)]
        public string TaxId { get; set; }
    }
}
