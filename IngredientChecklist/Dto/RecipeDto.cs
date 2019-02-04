using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IngredientChecklist.Dto
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
    }
}