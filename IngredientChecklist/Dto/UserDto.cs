using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IngredientChecklist.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}