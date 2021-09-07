using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Text.Json.Serialization;
using CountryApi.Extensions;
using CountryApi.Repositories.Country;
using CountryApi.Repositories.Mock;

namespace CountryApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.UseVersioning();
            services.UseSwagger();

            services.AddControllers(opt =>
            {
                opt.RespectBrowserAcceptHeader = true;
            });
            
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new IsoDateTimeConverter()
            {
                DateTimeFormat = "dd.MM.yyyy"
            });
            
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<ApplicationDbContext>(
                opt => opt.UseInMemoryDatabase("CountryDB"), ServiceLifetime.Singleton
                );
            services.AddRouting(opt => opt.LowercaseUrls = true);
            
            services.AddSingleton<IMockData, MockData>();
            services.AddSingleton<ICountryRepository, CountryRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersion, ILoggerFactory loggerFactory)
        {
            // loggerFactory.AddFile("Log/log-{Date}.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                foreach (var desc in apiVersion.ApiVersionDescriptions)
                    opt.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", desc.GroupName.ToUpperInvariant());
            });
        }
    }
}
