using CnD.CommunalPayments.Server.Api.Definitions.Base;
using CnD.CommunalPayments.Server.Dao.IMPL.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CnD.CommunalPayments.Server.Api.Definitions.DbContext
{
    public class DbContextDefinition : AppDefinitions
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<CommunalPaymentsDbContext>(config =>
        {
            // UseInMemoryDatabase - This for demo purposes only!
            // Should uninstall package "Microsoft.EntityFrameworkCore.InMemory" and install what you need. 
            // For example: "Microsoft.EntityFrameworkCore.SqlServer"
            // uncomment line below to use UseSqlServer(). Don't forget setup connection string in appSettings.json 
            //config.UseInMemoryDatabase("DEMO_PURPOSES_ONLY");

            // config.UseSqlServer(configuration.GetConnectionString(nameof(ApplicationDbContext)));

            config.UseSqlite("Data Source=apptest.db");
        });
    }
}
