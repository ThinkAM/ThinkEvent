using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ThinkAM.ThinkEvent.EntityFrameworkCore
{
    public static class ThinkEventDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ThinkEventDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ThinkEventDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
