using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IngredientChecklist.Models.DB;
using IngredientChecklist.IRepository;

namespace IngredientChecklist.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IngredientChecklistContext _context;
        public UserRepository(IngredientChecklistContext context)
        {
            _context = context;
        }
        public User GetUserByCredential(string userName, string password)
        {
            var user = _context.User.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            return user;
        }

        public User GetUserById(int id)
        {
            var user = _context.User.FirstOrDefault(u => u.Id == id);
            return user;
        }
    }
}