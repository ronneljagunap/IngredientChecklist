using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using IngredientChecklist.Models;
using IngredientChecklist.IRepository;
using IngredientChecklist.Repository;
using IngredientChecklist.Models.DB;
using IngredientChecklist.Dto;

namespace IngredientChecklist.Controllers
{

    public class LoginController : Controller
    {
        private IUserRepository _userRepository;
        public LoginController()
        {
            this._userRepository = new UserRepository(new IngredientChecklistContext());
        }

        // GET: Login
        public ActionResult Index()
        {
            Session["UserID"] = null;
            Session["FullName"] = null;

            return View(new UserDto());
        }

        [HttpPost]
        public ActionResult Index(UserDto user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var users = _userRepository.GetUserByCredential(user.UserName, user.Password);
                    Session["UserID"] = users.Id.ToString();
                    Session["FullName"] = users.FullName.ToString();
                    return RedirectToAction("Index", "Home", null);
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(user);
        }
    }
}