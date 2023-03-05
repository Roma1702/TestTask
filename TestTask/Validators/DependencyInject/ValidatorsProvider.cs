using DataAccessLayer.DTO;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace TestTask.Validators.DependencyInject
{
    public static class ValidatorsProvider
    {
        public static void ValidatorsProvide(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ShortPersonDto>, PersonValidator>();
        }
    }
}
