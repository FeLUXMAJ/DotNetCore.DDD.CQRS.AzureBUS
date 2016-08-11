
using MessageService.Domain;
using MessageService.Infra.Bus;
using Microsoft.Framework.DependencyInjection;

namespace MessageService.IoC
{
    public static class DependencyInjectorExtensions
    {
        public static IServiceCollection AddDependencyInjectors(this IServiceCollection service)
        {
            service.AddScoped<IBus, Bus>();
            return service;
        }
    }
}
