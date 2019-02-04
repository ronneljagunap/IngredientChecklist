using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientChecklist.Models.DB;

namespace IngredientChecklist.IRepository
{
    public interface IUserRepository
    {
        User GetUserByCredential(string userName, string password);

        User GetUserById(int id);
    }
}
