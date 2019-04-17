using System.Collections.Generic;
using Dal.Model;

namespace Dal.Interfases.Repository
{
    public interface IGameRepository : IRepository<Game>
    {
        IEnumerable<Game> GetByCustomerId(long customerId);
    }
}