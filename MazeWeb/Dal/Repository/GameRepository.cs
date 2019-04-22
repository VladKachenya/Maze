using Dal.EfStuff;
using MazeWebCore.Entities;
using MazeWebCore.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using MazeWebCore.Helpers.Attributes;

namespace Dal.Repository
{
    [ForRegistration]
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DataContext guessContext) : base(guessContext)
        {
        }

        public IEnumerable<Game> GetByCustomerId(long customerId)
        {
            return this.GetAll().Where(x => x.Gamer?.Id == customerId);
        }
    }
}