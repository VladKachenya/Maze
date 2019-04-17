using System.Collections.Generic;
using System.Linq;
using Dal.EfStuff;
using Dal.Interfases.Repository;
using Dal.Model;

namespace Dal.Repository
{
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