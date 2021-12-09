using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ABPCommerce.Authorization.Roles;
using ABPCommerce.Authorization.Users;
using ABPCommerce.MultiTenancy;
using ABPCommerce.Catalog.Product;
using ABPCommerce.OrderManagement.Order;
using ABPCommerce.OrderManagement.Shipping;
using ABPCommerce.OrderManagement.Billing;
using ABPCommerce.Catalog.Category;

namespace ABPCommerce.EntityFrameworkCore
{
    public class ABPCommerceDbContext : AbpZeroDbContext<Tenant, Role, User, ABPCommerceDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<BillingAddress> BillingAddresses { get; set; }

        public ABPCommerceDbContext(DbContextOptions<ABPCommerceDbContext> options)
            : base(options)
        {
        }
    }
}
