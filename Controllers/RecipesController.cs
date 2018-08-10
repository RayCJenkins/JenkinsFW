using Microsoft.AspNetCore.Mvc;
using JenkinsFW.Models;
using System.IO;
using System;
using JenkinsFW.Data;

namespace JenkinsFW.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {
            DBManager db = new DBManager();
            var recipe_list = db.LoadRecipes();
            var model = new RecipeListViewModel{
                Recipes = recipe_list
            };
            return View(model);
        } 

    }
}

