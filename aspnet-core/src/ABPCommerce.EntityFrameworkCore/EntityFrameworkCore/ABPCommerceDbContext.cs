using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ABPCommerce.Authorization.Roles;
using ABPCommerce.Authorization.Users;
using ABPCommerce.MultiTenancy;
using ABPCommerce.Catalog.Product;

namespace ABPCommerce.EntityFrameworkCore
{
    public class ABPCommerceDbContext : AbpZeroDbContext<Tenant, Role, User, ABPCommerceDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Product> Products { get; set; }

        public ABPCommerceDbContext(DbContextOptions<ABPCommerceDbContext> options)
            : base(options)
        {
        }
    }
}
