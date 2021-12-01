using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain.Entities;

namespace Recipe.Persistance.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<OakRecipe>
    {
        public void Configure(EntityTypeBuilder<OakRecipe> builder)
        {
            builder.HasKey(x => x.RecipeId);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(25);

            builder.HasData
            (
                new OakRecipe
                {
                    RecipeId = Guid.NewGuid(),
                    Name = "Oakmans favorite",
                    CreatedBy = "Oakman Admin",
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }

}
