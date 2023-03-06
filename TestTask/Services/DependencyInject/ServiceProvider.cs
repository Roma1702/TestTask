using Microsoft.Extensions.DependencyInjection;
using TestTask.Interfaces;

namespace TestTask.Services.DependencyInject
{
    public static class ServiceProvider
    {
        public static void ServicesProvide(this IServiceCollection services)
        {
            services.AddTransient<IProcessService, ProcessService>();
            services.AddTransient<IPersonBinder, PersonBinder>();
        }
    }
}
