using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IngredientChecklist.Dto
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RecipeId { get; set; }

        public bool IsChecked { get; set; }
    }
}