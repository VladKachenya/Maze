using MazeLogicCore.Engines;
using MazeLogicCore.Interfases.Builders;
using MazeLogicCore.Interfases.Engines;
using MazeModelCore.Interfases.ComplexModels;
using MazeModelCore.Interfases.Models;
using MazeModelCore.Models;
using MazeWebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MazeWebApp.Controllers
{
    public class MazeController : Controller
    {
        private readonly IMazeToCharConverter _mazeToCharConverter;
        private readonly IHero _hero;
        private readonly IEngine _engine;
        private readonly IMaze _maze;

        public MazeController(IMazeToCharConverter mazeToCharConverter, IHero hero, IMazeBuilder builder)
        {
            _mazeToCharConverter = mazeToCharConverter;
            _hero = hero;
            _maze = builder.ConstrainMaze(10, 15);
            _engine = new Processor(hero, _maze);
        }
        public IActionResult Index()
        {
            return View(_mazeToCharConverter.Convert(_maze));
        }
    }
}