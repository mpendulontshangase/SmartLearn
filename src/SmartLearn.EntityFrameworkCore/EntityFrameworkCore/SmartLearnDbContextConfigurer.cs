using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SmartLearn.EntityFrameworkCore
{
    public static class SmartLearnDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SmartLearnDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SmartLearnDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
