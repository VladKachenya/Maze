using System;
using Dal.Helper.CustomAttribute;
using Dal.Interfases.Repository;
using Dal.Interfases.Service;
using Dal.Model;

namespace Dal.Service
{
    [UseDi]
    public class PlayService : IPlayService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Game> _gameRepository;

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