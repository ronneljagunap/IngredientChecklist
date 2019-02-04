using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace IngredientChecklist.Models.DB
{
    public class IngredientChecklistContext : DbContext
    {

        public IngredientChecklistContext()
            : base("name=ConnectionString")
        {
        }

        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
        }
    }
}