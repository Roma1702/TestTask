using DataAccessLayer.Repositories.DependencyInject;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Services.DependencyInject;
using TestTask.Validators.DependencyInject;

namespace TestTask
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.RepositoriesProvide();
            services.ServicesProvide();
            services.MappersProvide();
            services.ValidatorsProvide();

            var serviceProvider = services.BuildServiceProvider();

            var processService = serviceProvider.GetService<IProcessService>();
            await processService!.Process(args);
        }
    }
}