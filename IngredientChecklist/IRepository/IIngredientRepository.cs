using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientChecklist.Models.DB;
using IngredientChecklist.Dto;

namespace IngredientChecklist.IRepository
{
    public interface IIngredientRepository
    {
        bool UpdateIngredient(IngredientDto ingredient);

        //bool ResetIngredientSelection(int id);
        IQueryable<Recipe> GetRecipesByUser(int id);
        IQueryable<Ingredient> GetIngredientByRecipe(int id);

        int AddNewIngredient(IngredientDto ingredient);

        int DeleteIngredient(int Id);

    }
}
