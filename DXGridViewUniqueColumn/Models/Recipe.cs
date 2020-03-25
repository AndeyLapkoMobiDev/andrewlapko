using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXGridViewUniqueColumn.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}