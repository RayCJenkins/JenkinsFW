using Microsoft.AspNetCore.Mvc;
using JenkinsFW.Models;
using System.IO;
using System;
using JenkinsFW.Data;

namespace JenkinsFW.Controllers
{
    public class AddRecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 

        [HttpPost]
        public IActionResult SaveRecipe([FromBody]SaveRecipeModel data)
        {
            //var temp = Request.Body;
            Console.WriteLine(string.Format("{0}: {1}:{2}; {3}:{4}; {5}:{6}; {7}:{8}; {9}:{10}; ",
            nameof(SaveRecipe), nameof(data.title), data.title,
            nameof(data.description), data.description,
            nameof(data.prepTime), data.prepTime,
            nameof(data.cookTime), data.cookTime,
            nameof(data.instructions), data.instructions));
            DBManager db = new DBManager();
            db.loadrecipe();
            return new JsonResult(data);
        }
    }
}