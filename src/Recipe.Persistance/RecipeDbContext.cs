using Microsoft.EntityFrameworkCore;
using Recipe.Domain.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Recipe.Domain.Entities;

namespace Recipe.Persistance
{
    public interface IRecipeDbContext
    {
    }

    public class RecipeDbContext : DbContext, IRecipeDbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
            : base(options)
        {
        }

        public DbSet<OakRecipe> OakRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    default:
                        throw new ArgumentException("No Entry State added / found.");
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
