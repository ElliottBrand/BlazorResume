using Microsoft.Extensions.DependencyInjection;

namespace BlazorResume.Client.Components.Alert
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAlert(this IServiceCollection services)
        {
            return services.AddTransient<AlertState>();
        }
    }
}
