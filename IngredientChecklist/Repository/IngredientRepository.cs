using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientChecklist.IRepository;
using IngredientChecklist.Models.DB;
using IngredientChecklist.Dto;

namespace IngredientChecklist.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IngredientChecklistContext _context;
        public IngredientRepository(IngredientChecklistContext context)
        {
            _context = context;
        }
        public bool UpdateIngredient(IngredientDto ingredientDto)
        {
            var ingredient = _context.Ingredient.FirstOrDefault(i => i.Id == ingredientDto.Id);
            ingredient.Name = ingredientDto.Name;
            ingredient.IsChecked = ingredientDto.IsChecked;
            _context.SaveChanges();
            return true;
        }

        public IQueryable<Recipe> GetRecipesByUser(int id)
        {
            var recipes = _context.Recipe.Where(r => r.UserId == id);
            return recipes;
        }

        public IQueryable<Ingredient> GetIngredientByRecipe(int id)
        {
            var ingredients = _context.Ingredient.Where(r => r.RecipeId == id);
            return ingredients;
        }

        public int AddNewIngredient(IngredientDto ingredientDto)
        {
            Ingredient ingredient = new Ingredient
            {
                Name = ingredientDto.Name,
                RecipeId = ingredientDto.RecipeId,
            };
            _context.Ingredient.Add(ingredient);
            _context.SaveChanges();
            return ingredient.Id;
        }

        public int DeleteIngredient(int Id)
        {
            Ingredient ingredient = (from c in _context.Ingredient
                                     where c.Id == Id
                                     select c).FirstOrDefault();
            _context.Ingredient.Remove(ingredient);
            _context.SaveChanges();
            return ingredient.Id;
        }

    }
}
