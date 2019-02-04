using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IngredientChecklist.Models.DB;
using IngredientChecklist.IRepository;
using IngredientChecklist.Repository;
using IngredientChecklist.Dto;

namespace IngredientChecklist.Controllers
{
    public class RecipeController : Controller
    {
        private IRecipeRepository _recipeRepository;

        public RecipeController()
        {
            this._recipeRepository = new RecipeRepository(new IngredientChecklistContext());
        }
        // GET: Recipe
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Index", "Login", null);
            return View();
        }

        public ActionResult Recipe()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Login", "Login", null);
            try
            {
                if (ModelState.IsValid)
                {
                    int userID = Convert.ToInt32(Session["UserID"]);
                    var recipes = _recipeRepository.GetRecipesByUser(userID);
                    return View(recipes);
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return null;
        }
        public ActionResult Create()
        {
            var recipeDto = new RecipeDto();
            recipeDto.UserId = Convert.ToInt32(Session["UserID"]);
            return View(recipeDto);
        }

        [HttpPost]
        public ActionResult Create(RecipeDto recipe)
        {
            int id = _recipeRepository.AddNewRecipe(recipe);
            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult Edit(int id)
        {
            var recipe = _recipeRepository.GetRecipesById(id);
            var recipeDto = new RecipeDto();
            recipeDto.Id = recipe.Id;
            recipeDto.Name = recipe.Name;
            return View(recipeDto);
        }

        [HttpPost]
        public ActionResult Edit(RecipeDto recipe)
        {
            int id = _recipeRepository.UpdateRecipe(recipe);
            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult Ingredients(int id, string name)
        {
            Session["RecipeID"] = id;
            Session["RecipeName"] = name;
            return RedirectToAction("Index", "Ingredients", null);
        }

        public ActionResult Cook(int id, string name)
        {
            Session["RecipeID"] = id;
            Session["RecipeName"] = name;
            //return RedirectToAction("Index", "Cook", null);
            return RedirectToAction("Index", "Cooking", null);
        }

        public ActionResult ModalPopUp()
        {
            return View();
        }

    }
}