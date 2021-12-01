using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe.Application.Interfaces;
using Recipe.Persistance.Repositories.Base;

namespace Recipe.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RecipeDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RecipeConnectionString")));

            services.AddScoped<IRecipeDbContext, RecipeDbContext>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
