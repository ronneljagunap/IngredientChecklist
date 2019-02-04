using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IngredientChecklist.Models.DB
{
    public partial class Ingredient
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsChecked { get; set; }
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}