using Microsoft.AspNetCore.Mvc;

namespace JenkinsFW.Controllers
{
    public class AddRecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
    }
}