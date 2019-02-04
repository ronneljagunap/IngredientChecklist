using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientChecklist.Models.DB;
using IngredientChecklist.Dto;

namespace IngredientChecklist.IRepository
{
    public interface IRecipeRepository
    {
        Recipe GetRecipesById(int RecipeID);

        IQueryable<Recipe> GetRecipesByUser(int id);

        int AddNewRecipe(RecipeDto recipe);

        int UpdateRecipe(RecipeDto recipe);
    }
}
