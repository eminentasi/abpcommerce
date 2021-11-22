using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ABPCommerce.EntityFrameworkCore
{
    public static class ABPCommerceDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ABPCommerceDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ABPCommerceDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
