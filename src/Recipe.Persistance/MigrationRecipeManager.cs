using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Recipe.Persistance
{
    public static class MigrationRecipeManager
    {
        public static async Task<IWebHost> MigrateRecipeDatabase(this IWebHost iHost)
        {
            using (var scope = iHost.Services.CreateScope())
            using (var recipeContext = scope.ServiceProvider.GetRequiredService<RecipeDbContext>())
            {
                var services = scope.ServiceProvider;
                // LoggerFactory here
                // Add Logger

                try
                {
                    await recipeContext.Database.MigrateAsync();
                }
                catch (Exception e)
                {
                    throw new Exception("Migration RecipeDb failed", e);
                }

            }

           
            return iHost;
        }
    }
}
