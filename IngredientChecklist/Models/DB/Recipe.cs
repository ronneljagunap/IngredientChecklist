using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IngredientChecklist.Models.DB
{
    public partial class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Ingredient> Ingredient { get; set; }
    }
}