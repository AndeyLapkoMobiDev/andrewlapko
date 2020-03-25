using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXGridViewUniqueColumn.Models
{
    public static class Data
    {
        public static List<Ingredient> Ingredients { get; set; }
        public static List<Recipe> Recipes { get; set; }

        static Data()
        {
            Ingredients = new List<Ingredient>()
            {
                new Ingredient(){Id = 1, Name = "ingredient1"},
                new Ingredient(){Id = 2, Name = "ingredient2"},
                new Ingredient(){Id = 3, Name = "ingredient3"},
            };

            Recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Id = 1, 
                    Name = "recipe1",
                    RecipeIngredients = new List<RecipeIngredient>()
                    {
                        new RecipeIngredient() {Id = Guid.NewGuid(), RecipeId = 1, IngredientId = 1, Weight = 1.1},
                        new RecipeIngredient() {Id = Guid.NewGuid(), RecipeId = 1, IngredientId = 2, Weight = 1.2},
                    }
                },
                new Recipe()
                {
                    Id = 2, 
                    Name = "recipe2",
                    RecipeIngredients = new List<RecipeIngredient>()
                    {
                        new RecipeIngredient() {Id = Guid.NewGuid(), RecipeId = 2, IngredientId = 2, Weight = 2.2},
                        new RecipeIngredient() {Id = Guid.NewGuid(), RecipeId = 2, IngredientId = 3, Weight = 2.3},
                    }
                }
            };
        }
    }
}