using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXGridViewUniqueColumn.Models
{
    public class RecipeIngredient
    {
        public Guid Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public double Weight { get; set; }
    }
}