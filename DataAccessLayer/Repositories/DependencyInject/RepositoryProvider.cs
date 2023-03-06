using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Repositories.DependencyInject
{
    public static class RepositoryProvider
    {
        public static void RepositoriesProvide(this IServiceCollection services)
        {
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddDbContext<ApplicationContext>();
        }
    }
}
