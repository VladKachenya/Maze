using MazeWebCore.Entities;
using MazeWebCore.Helpers.Attributes;
using MazeWebCore.Interfaces.Repositories;
using MazeWebCore.Interfaces.Services;
using System;

namespace MazeWebCore.Sevices
{
    [ForRegistration]
    public class PlayService : IPlayService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Game> _gameRepository;

        [Injection]
        public PlayService(IRepository<Customer> customerRepository, IRepository<Game> gameRepository)
        {
            _customerRepository = customerRepository;
            _gameRepository = gameRepository;
        }

        public void Play(Game game)
        {
            game.Gamer = _customerRepository.Get(game.Gamer.Id);
            game.Date = DateTime.Now;
            _gameRepository.Add(game);
        }
    }
}