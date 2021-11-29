using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ABPCommerce.Authorization.Roles;
using ABPCommerce.Authorization.Users;
using ABPCommerce.MultiTenancy;
using ABPCommerce.Catalog.Product;
using ABPCommerce.OrderManagement.Order;

namespace ABPCommerce.EntityFrameworkCore
{
    public class ABPCommerceDbContext : AbpZeroDbContext<Tenant, Role, User, ABPCommerceDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public ABPCommerceDbContext(DbContextOptions<ABPCommerceDbContext> options)
            : base(options)
        {
        }
    }
}
