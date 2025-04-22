using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChanelCategorySearcher.DAI;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<AppDbContext>(options =>
        {
            var connectionConf = configuration.GetConnectionString("PostgresConnection");

           options.LogTo(Console.WriteLine);
           //options.UseNpgsql("Host=db;Port=5432;Database=postgres;Username=postgres;Password=admin");
           options.UseNpgsql(connectionConf);
        });
        serviceCollection.AddScoped<IChanelRepository, ChanelRepository>();
        return serviceCollection;
    }
}