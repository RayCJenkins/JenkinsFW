using Microsoft.AspNetCore.Mvc;
using JenkinsFW.Models;
using System.IO;
using System;

namespace JenkinsFW.Controllers
{
    public class AddRecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 

        [HttpPost]
        public IActionResult SaveRecipe(SaveRecipeModel data)
        {
            Console.WriteLine(string.Format("{0}: {1}:{2}; {3}:{4}; {5}:{6}; {7}:{8}; {9}:{10}; ",
            nameof(SaveRecipe), nameof(data.title), data.title,
            nameof(data.description), data.description,
            nameof(data.prepTime), data.prepTime,
            nameof(data.cookTime), data.cookTime,
            nameof(data.instructions), data.instructions));
            return new JsonResult(data);
        }
    }
}