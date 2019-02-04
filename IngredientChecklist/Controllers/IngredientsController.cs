using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IngredientChecklist.Dto;
using IngredientChecklist.Models.DB;
using IngredientChecklist.IRepository;
using IngredientChecklist.Repository;

namespace IngredientChecklist.Controllers
{
    public class IngredientsController : Controller
    {
        private IIngredientRepository _ingredientRepository;
        public IngredientsController()
        {
            this._ingredientRepository = new IngredientRepository(new IngredientChecklistContext());
        }
        // GET: Ingredients
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Index", "Login", null);

            int recipeID = Convert.ToInt32(Session["RecipeID"]);
            var ingredient = _ingredientRepository.GetIngredientByRecipe(recipeID);
            var viewitems = new List<IngredientDto>();
            viewitems.Add(new IngredientDto());
            foreach (var item in ingredient)
            {
                var dto = new IngredientDto();
                dto.Id = item.Id;
                dto.Name = item.Name;
                dto.IsChecked = Convert.ToBoolean(item.IsChecked);
                dto.RecipeId = item.RecipeId;
                viewitems.Add(dto);
            }
            return View(viewitems);
        }

        [HttpPost]
        public JsonResult InsertIngredient(IngredientDto ingredient)
        {
            if (!string.IsNullOrEmpty(ingredient.Name))
            {
                int recipeID = Convert.ToInt32(Session["RecipeID"]);
                ingredient.RecipeId = recipeID;
                ingredient.Id = _ingredientRepository.AddNewIngredient(ingredient);
                return Json(ingredient);
            }
            return null;
        }

        [HttpPost]
        public ActionResult UpdateIngredient(IngredientDto ingredient)
        {
            if (ingredient.Id != 0)
            {
                int recipeID = Convert.ToInt32(Session["RecipeID"]);
                ingredient.RecipeId = recipeID;
                _ingredientRepository.UpdateIngredient(ingredient);
            }
            return Json(new { success = true, responseText = "Updated sucessfully!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteIngredient(int Id)
        {
            _ingredientRepository.DeleteIngredient(Id);
            return Json(new { success = true, responseText = "Delete sucessfully!" }, JsonRequestBehavior.AllowGet);
        }
    }
}