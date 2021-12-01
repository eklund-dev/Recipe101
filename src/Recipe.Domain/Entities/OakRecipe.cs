using System;
using Recipe.Domain.Common;

namespace Recipe.Domain.Entities
{
    public class OakRecipe : AuditableEntity
    {
        public Guid RecipeId { get; set; }
        public string Name { get; set; }
    }
}
