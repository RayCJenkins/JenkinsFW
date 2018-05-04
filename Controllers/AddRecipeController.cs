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
        public IActionResult SaveRecipe([FromBody] SaveRecipeModel data)
        {
            // Console.WriteLine(string.Format("{0}: {1}:{2}; {3}:{4}; {5}:{6}; {7}:{8}; {9}:{10}; ",
            // nameof(SaveRecipe), nameof(data.Title), data.Title,
            // nameof(data.Description), data.Description,
            // nameof(data.PrepTime), data.PrepTime,
            // nameof(data.CookTime), data.CookTime,
            // nameof(data.Instructions), data.Instructions));
            return new JsonResult(data);
        }
    }
}