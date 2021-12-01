using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Recipe.Common.Interfaces;

namespace Recipe.WebApi.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddHealthChecks();

            services.AddMvcCore(options =>
                {
                    options.EnableEndpointRouting = false;
                    //options.Filters.Add(new ControllerValidationFilter());
                })
                .AddFluentValidation(mvcConfig =>
                    mvcConfig.RegisterValidatorsFromAssemblyContaining<Startup>());
            
            services.AddAuthorization();
        }
    }
}
