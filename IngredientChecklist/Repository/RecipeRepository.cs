using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IngredientChecklist.Models.DB;
using IngredientChecklist.Dto;
using IngredientChecklist.IRepository;

namespace IngredientChecklist.Repository
{
    public class RecipeRepository :IRecipeRepository
    {
        private readonly IngredientChecklistContext _context;
        public RecipeRepository(IngredientChecklistContext context)
        {
            _context = context;
        }

        public Recipe GetRecipesById(int RecipeID)
        {
            var recipe = _context.Recipe.FirstOrDefault(r => r.Id == RecipeID);
            return recipe;
        }

        public IQueryable<Recipe> GetRecipesByUser(int id)
        {
            var recipes = _context.Recipe.Where(r => r.UserId == id);
            return recipes;
        }

        public int AddNewRecipe(RecipeDto recipeDto)
        {
            Recipe recipe = new Recipe
            {
                Name = recipeDto.Name,
                UserId = recipeDto.UserId,
            };
            _context.Recipe.Add(recipe);
            _context.SaveChanges();
            return recipe.Id;
        }

        public int UpdateRecipe(RecipeDto recipeDto)
        {
            var recipe = _context.Recipe.FirstOrDefault(r => r.Id == recipeDto.Id);
            recipe.Name = recipeDto.Name;
            _context.SaveChanges();
            return recipe.Id;
        }
    }
}