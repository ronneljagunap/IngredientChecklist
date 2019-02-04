﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IngredientChecklist.Models.DB
{
    public partial class User
    {
        public User()
        {
            Recipe = new HashSet<Recipe>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid Guid { get; set; }

        public ICollection<Recipe> Recipe { get; set; }
    }
}