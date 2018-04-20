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

        public IActionResult SaveRecipe(SaveRecipeModel Model)
        {
            Console.WriteLine(string.Format("{0}: {1}:{2}; {3}:{4}; {5}:{6}; {7}:{8}; {9}:{10}; ",
            nameof(SaveRecipe), nameof(Model.Title), Model.Title,
            nameof(Model.Description), Model.Description,
            nameof(Model.PrepTime), Model.PrepTime,
            nameof(Model.CookTime), Model.CookTime,
            nameof(Model.Instructions), Model.Instructions));
        }
    }
}