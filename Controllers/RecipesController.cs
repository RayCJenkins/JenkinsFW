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
            return View();
        } 
    }
}

