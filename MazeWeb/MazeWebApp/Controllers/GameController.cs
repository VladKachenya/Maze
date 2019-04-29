using MazeWebCore.Entities;
using MazeWebCore.Interfaces.Repositories;
using MazeWebCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MazeWebApp.Controllers
{
    public class GameController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IPlayService _playService;

        public GameController(IRepository<Customer> customerRepository, IGameRepository gameRepository, IPlayService playService)
        {
            _customerRepository = customerRepository;
            _gameRepository = gameRepository;
            _playService = playService;
        }
        public IActionResult Index()
        {
            return View(_gameRepository.GetAll().ToList());
        }


        [HttpGet]
        public IActionResult GustomerGameProfile(long customerId)
        {
            var customer = _customerRepository.Get(customerId);
            customer.Games = _gameRepository.GetByCustomerId(customerId).ToList();
            return View(customer);
        }

        public IActionResult Play(Game game)
        {
            _playService.Play(game);
            //return RedirectToAction("GustomerGameProfile", new { customerId = game.Gamer.Id });
            return RedirectToRoute("default");//"~/Maze/Index"
        }

    }
}