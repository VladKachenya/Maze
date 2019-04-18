using MazeModelCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MazeWebApp.Controllers
{
    public class MazeController : Controller
    {
        public MazeController()
        {
            var hero = new Hero();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}