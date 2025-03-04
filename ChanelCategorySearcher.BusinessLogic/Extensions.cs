using ChanelCategorySearcher.DAI;
using Microsoft.Extensions.DependencyInjection;

namespace ChanelCategorySearcher.BusinessLogic;

public static class Extensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IChanelService, ChanelService>();
        return serviceCollection;
    }
}