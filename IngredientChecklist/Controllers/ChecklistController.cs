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
    public class ChecklistController : Controller
    {

        private IIngredientRepository _ingredientRepository;
        public ChecklistController()
        {
            this._ingredientRepository = new IngredientRepository(new IngredientChecklistContext());
        }

        // GET: Cooking
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Index", "Login", null);

            int userID = Convert.ToInt32(Session["UserID"]);
            var recipes = _ingredientRepository.GetRecipesByUser(userID);
            List<SelectListItem> RecipesList = recipes.Select(r => new SelectListItem { Text = r.Name, Value = r.Id.ToString() }).ToList();
            ViewBag.Recipes = RecipesList;
            var ingredients = new List<IngredientDto>();
            return View(ingredients);

        }

        public PartialViewResult GetItem(int id)
        {
            var ingredient = _ingredientRepository.GetIngredientByRecipe(id);
            var viewitems = new List<IngredientDto>();
            foreach (var item in ingredient)
            {
                var dto = new IngredientDto();
                dto.Id = item.Id;
                dto.Name = item.Name;
                dto.IsChecked = Convert.ToBoolean(item.IsChecked);
                viewitems.Add(dto);
            }
            return PartialView("_GetItem", viewitems);

        }

        [HttpPost]
        public ActionResult UpdateIngredient(IngredientDto ingredient)
        {
            if (ingredient.Id != 0)
            {
                _ingredientRepository.UpdateIngredient(ingredient);
            }
            return Json(new { success = true, responseText = "Updated sucessfully!" }, JsonRequestBehavior.AllowGet);
        }

    }
}