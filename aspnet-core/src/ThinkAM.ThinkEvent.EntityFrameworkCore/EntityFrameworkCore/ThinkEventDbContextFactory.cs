using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ThinkAM.ThinkEvent.Configuration;
using ThinkAM.ThinkEvent.Web;

namespace ThinkAM.ThinkEvent.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ThinkEventDbContextFactory : IDesignTimeDbContextFactory<ThinkEventDbContext>
    {
        public ThinkEventDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ThinkEventDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ThinkEventDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ThinkEventConsts.ConnectionStringName));

            return new ThinkEventDbContext(builder.Options);
        }
    }
}
