using System;
using MazeModelCore.Interfases.ComplexModels;
using MazeWebCore.Entities;
using MazeWebCore.Helpers.Attributes;
using MazeWebCore.Interfaces.Repositories;
using MazeWebCore.Interfaces.Services;

namespace MazeWebCore.Sevices
{
    [ForRegistration]
    public class PlayService : IPlayService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Game> _gameRepository;
        private IMaze _mazeProm;

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

        [Injection]
        public IMaze MazeProm
        {
            get => _mazeProm;
            set
            {
                _mazeProm = value;
            }
        }
    }
}