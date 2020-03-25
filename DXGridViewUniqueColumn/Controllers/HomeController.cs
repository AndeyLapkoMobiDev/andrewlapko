using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXGridViewUniqueColumn.Models;

namespace DXGridViewUniqueColumn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region Recipes

        [ValidateInput(false)]
        public ActionResult RecipesGridView()
        {
            return PartialView("_RecipesGridView", Data.Recipes);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddRecipe(Recipe item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Data.Recipes.Add(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            return RecipesGridView();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateRecipe(Recipe item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = Data.Recipes.FirstOrDefault(i => i.Id == item.Id);
                    if (modelItem != null)
                    {
                        var index = Data.Recipes.IndexOf(modelItem);
                        Data.Recipes[index] = item;
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            return RecipesGridView();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DeleteRecipe(int id)
        {
            if (id >= 0)
            {
                try
                {
                    var item = Data.Recipes.FirstOrDefault(i => i.Id == id);
                    if (item != null)
                    {
                        Data.Recipes.Remove(item);
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            return RecipesGridView();
        }

        #endregion

        #region RecipeIngredients

        public ActionResult RecipeIngredientsGrid(int recipeId)
        {
            ViewData["recipeId"] = recipeId;

            var model = Data.Recipes
                .Where(r => r.Id == recipeId)
                .SelectMany(r => r.RecipeIngredients)
                .ToList();

            return PartialView("_RecipeIngredientsGrid", model);
        }

        public ActionResult RecipeIngredientsBatchUpdate(MVCxGridViewBatchUpdateValues<RecipeIngredient, Guid> batchValues, int recipeId)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            return RecipeIngredientsGrid(recipeId);
        }

        #endregion
    }
}