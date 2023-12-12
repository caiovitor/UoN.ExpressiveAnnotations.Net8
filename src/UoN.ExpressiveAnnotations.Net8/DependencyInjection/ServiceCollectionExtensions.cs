using Microsoft.Extensions.DependencyInjection;
using UoN.ExpressiveAnnotations.Net8.Caching;

namespace UoN.ExpressiveAnnotations.Net8.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddExpressiveAnnotations(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<RequestCache>();
        }
    }
}
