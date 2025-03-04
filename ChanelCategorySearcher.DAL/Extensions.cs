using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChanelCategorySearcher.DAI;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<AppDbContext>(options =>
        {
           // var connectionConf = options.Configuration["PostgresConnection"];

            options.LogTo(Console.WriteLine);
            options.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=admin");
        });
        serviceCollection.AddScoped<IChanelRepository, ChanelRepository>();
        return serviceCollection;
    }
}