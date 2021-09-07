using Microsoft.Extensions.DependencyInjection;

namespace CountryApi.Extensions
{
    public static class Swagger
    {
        public static void UseSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }
    }
}
