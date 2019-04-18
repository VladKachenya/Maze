using MazeModelCore.Models;
using MazeWebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MazeWebApp.Controllers
{
    public class MazeController : Controller
    {
        private readonly IMazeToCharConverter _mazeToCharConverter;

        public MazeController(IMazeToCharConverter mazeToCharConverter)
        {
            _mazeToCharConverter = mazeToCharConverter;
            var hero = new Hero();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}